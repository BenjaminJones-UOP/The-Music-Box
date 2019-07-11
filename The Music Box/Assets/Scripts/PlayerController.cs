using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2.0f;
    public float sensitivity = 2.0f;
    CharacterController player;

    public objectDetection objectDetectScript;
    public GameObject eyes;

    GameObject walls;

    float moveFB;
    float moveLR;

    float rotX;
    float rotY;

    float gravity = 4.0f;

    float stepCycle;
    public float stepCycleThreshold = 1;

    float panRange = 10.0f;
    float panAmountL;
    float panAmountR;
    float panAmount;

    Vector3 wallsClosestPos;

    float leftAngle;
    float rightAngle;

    RaycastHit objectInteractRayHit;
    Ray centreScreenRay;
    float SphereAngle;

    Ray leftRay;
    Ray rightRay;

    Ray SphereRay;
    RaycastHit SphereRayHit;

    RaycastHit leftRayHit;
    RaycastHit rightRayHit;

    public bool mouseOverObject;
    bool frontDoorDetected;
    bool backDoorDetected;
    bool bedroomDoorDetected;
    bool atticDoorDetected;
    bool gotBackDoorKey = false;
    bool gotBedroomDoorKey = false;
    bool gotAtticKey = false;

    bool playOncePlug;

    void Start()
    {
        playOncePlug = true;

        stepCycle = 0f;
        player = GetComponent<CharacterController>();

        AkSoundEngine.SetState("TaskController", "Task0_ClockOn");
        AkSoundEngine.SetState("HitWall", "Off");

        eyes = GameObject.FindWithTag("MainCamera");

    }

    void Update() 
    {
    
        //movement code
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotY += Input.GetAxis("Mouse Y") * sensitivity;
        rotX = Input.GetAxis("Mouse X") * sensitivity;

        rotY = Mathf.Clamp(rotY, -90, 90);

        Vector3 movement = new Vector3(moveLR, -gravity, moveFB);
        transform.Rotate(0, rotX, 0);

        eyes.transform.localEulerAngles = new Vector3(-rotY, eyes.transform.localEulerAngles.y, eyes.transform.localEulerAngles.z);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        //footsteps code
        if (player.velocity.magnitude > 0)
        {
            FootSteps(stepCycleThreshold);
        }

        if(player.velocity.magnitude == 0)
        {
            stepCycle = 0;
        }

        //interaction code
        centreScreenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(centreScreenRay, out objectInteractRayHit, 5.0f))
        {
            if (objectInteractRayHit.transform.tag != "Untagged" && objectInteractRayHit.transform.tag != "WallObject")
            {
                mouseOverObject = true;
                //print("Detect object");

                if (objectInteractRayHit.transform.tag == "Front Door")
                {
                    frontDoorDetected = true;
                }

                if (objectInteractRayHit.transform.tag == "Back Door")
                {
                    backDoorDetected = true;
                }

                if (objectInteractRayHit.transform.tag == "Bedroom Door")
                {
                    bedroomDoorDetected = true;
                }

                if (objectInteractRayHit.transform.tag == "Attic")
                {
                    atticDoorDetected = true;
                }

                if (objectInteractRayHit.transform.tag == "Clock")
                {
                    if (objectDetectScript.GetMouseDownBool())
                    {
                        gotBackDoorKey = true;
                        //Got back door key now, play sound here for collecting back door key
                    }
                }

                if (objectInteractRayHit.transform.tag == "Generator")
                {
                    if (objectDetectScript.GetMouseDownBool())
                    {
                        gotBedroomDoorKey = true;
                        //Got bedroom door key now, do generator turn off noise here
                    }
                }

                if (objectInteractRayHit.transform.tag == "Bath")
                {
                    if (objectDetectScript.GetMouseDownBool())
                    {
                        gotAtticKey = true;
                        if (playOncePlug)
                        {
                            AkSoundEngine.PostEvent("Pull_Plug", GameObject.FindWithTag("Bath"));
                            AkSoundEngine.SetState("TaskController", "Task3_AllOff");
                            playOncePlug = false;
                        }
                        //got attic key from Bath
                    }
                }



            }

            //if detecting an untagged object
            else
            {
                mouseOverObject = false;
                //print("No Object");
                frontDoorDetected = false;
                backDoorDetected = false;
                bedroomDoorDetected = false;
            }

        }
        //if detecting no object
        else { mouseOverObject = false; } //print("No Object"); }




    }

    //Footsteps code
    void FootSteps(float threshold){

        if (stepCycle > threshold) { 
            AkSoundEngine.PostEvent("FootstepsEvent", gameObject);
            AkSoundEngine.PostEvent("Wallhits", gameObject);
            stepCycle = 0;

        }
        stepCycle += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        //Statement to slow down player when on stairs to add more creaky footsteps
        if (other.tag == "Stairs" || other.tag == "StairsAttic") { speed = 4.0f; stepCycleThreshold = 1.0f; }
        else { speed = 8.0f; stepCycleThreshold = 0.55f; }

        //Switch case to determine:
        // - foot steps
        // - Hitting door noise
        switch (other.tag) {
            case "Wall":
                //AkSoundEngine.SetState("HitWall", "Wall");
                //Not needed but staying for potential debugging
                break;
            case "Indoor":
                AkSoundEngine.SetState("HitWall", "Indoor");
                break;
            case "Outdoor":
                AkSoundEngine.SetState("HitWall", "Outdoor");
                break;
            case "Carpet":
                AkSoundEngine.SetState("FootstepsSwitch", "Carpet");
                break;
            case "Floorboards":
                AkSoundEngine.SetState("FootstepsSwitch", "Floorboards");
                break;
            case "Grass":
                AkSoundEngine.SetState("FootstepsSwitch", "Grass");
                break;
            case "Stairs":
                AkSoundEngine.SetState("FootstepsSwitch", "Stairs");
                break;
            case "StairsAttic":
                AkSoundEngine.SetState("FootstepsSwitch", "StairsAttic");
                break;
            case "Tiles":
                AkSoundEngine.SetState("FootstepsSwitch", "Tiles");
                break;
            case "WetTiles":
                AkSoundEngine.SetState("FootstepsSwitch", "WetTiles");
                break;

            default:
                //Doesn't exist, always hitting something
                break;

        }
    }

    //Playing rubbing up against wall sound when next to wall
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Wall") 
        {
            AkSoundEngine.SetState("HitWall", "Wall");
        }

        if (other.tag == "Wall")
        {
            //Audio panning code for wall rub, necessary for orientation of player on wall
            Vector3 left = new Vector3(-5, 0, 0);
            Vector3 right = new Vector3(5, 0, 0);

            Vector3 left1 = transform.TransformDirection(left);
            Vector3 right1 = transform.TransformDirection(right);

            Debug.DrawRay(transform.position, left1, Color.green);
            Debug.DrawRay(transform.position, right1, Color.green);

            leftRay = new Ray(transform.position, left1);
            rightRay = new Ray(transform.position, right1);


            if (Physics.Raycast(leftRay, out leftRayHit, 5.0f))
            {
                if (leftRayHit.transform.CompareTag("WallObject"))
                {
                    AkSoundEngine.SetRTPCValue("WallPan", leftAngle);
                }
                else { AkSoundEngine.SetRTPCValue("WallPan", 0.0f); }
            }

            if (Physics.Raycast(rightRay, out rightRayHit, 5.0f))
            {
                if (rightRayHit.transform.CompareTag("WallObject"))
                {
                    AkSoundEngine.SetRTPCValue("WallPan", rightAngle);
                }
                else { AkSoundEngine.SetRTPCValue("WallPan", 0.0f); }
            }

            Collider[] hitCollider = Physics.OverlapSphere(transform.position, 5.0f);

            for (int i = 0; i < hitCollider.Length; i++)
            {
                if (hitCollider[i].tag == "WallObject")
                {
                    wallsClosestPos = hitCollider[i].ClosestPoint(gameObject.transform.localPosition);
                }
            }

            leftAngle = Vector3.SignedAngle(leftRayHit.point - transform.position, wallsClosestPos - transform.position, Vector3.up);
            rightAngle = Vector3.SignedAngle(rightRayHit.point - transform.position, wallsClosestPos - transform.position, Vector3.up);

            Debug.DrawRay(transform.position, wallsClosestPos - transform.position, Color.blue);

            Debug.DrawRay(wallsClosestPos, leftRayHit.point - wallsClosestPos, Color.red);
            Debug.DrawRay(wallsClosestPos, rightRayHit.point - wallsClosestPos, Color.red);

            leftAngle += 90.0f;
            rightAngle -= 90.0f;

            Debug.Log("Left Angle = " + leftAngle);
            Debug.Log("Right Angle = " + rightAngle);
        }


    }

    //Changes the rub wall/door noise back to nothing when exiting the wall/door
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Indoor" || other.tag == "Outdoor")
        {
            AkSoundEngine.SetState("HitWall", "off");
        }
    }


    //getters to send to other scripts
    public bool GetFrontDoorDetect() { return frontDoorDetected; }
    public bool GetBackDoorDetect() { return backDoorDetected; }
    public bool GetBedroomDoorDetect() { return bedroomDoorDetected; }
    public bool GetAtticDoorDetect() { return atticDoorDetected; }
    public bool GetBackDoorKey() { return gotBackDoorKey; }
    public bool GetBedroomDoorKey() { return gotBedroomDoorKey; }
    public bool GetAtticKey() { return gotAtticKey; }

}