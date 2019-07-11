using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedroomDoor : MonoBehaviour {

    public Animation openDoorAnim;
    public objectDetection objectDetectScript;
    public PlayerController playerControllerScript;

    bool playOnce;

    // Use this for initialization
    void Start()
    {
        playOnce = true;
        openDoorAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        if (objectDetectScript.GetMouseDownBool() && playerControllerScript.GetBedroomDoorDetect() && playerControllerScript.GetBedroomDoorKey())
        {

            if (playOnce)
            {
                AkSoundEngine.PostEvent("Open_Indoor_Door", gameObject);
                playOnce = false;
            }
            openDoorAnim.Play();
        }
    }
}