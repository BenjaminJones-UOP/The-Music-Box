using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticDoor : MonoBehaviour {

    public Animation openDoorAnim;
    public objectDetection objectDetectScript;
    public PlayerController playerControllerScript;

    bool once;

    // Use this for initialization
    void Start()
    {
        once = true;
        openDoorAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        if (objectDetectScript.GetMouseDownBool() && playerControllerScript.GetAtticDoorDetect() && playerControllerScript.GetAtticKey())
        {

            if (once)
            {
                AkSoundEngine.PostEvent("Open_Indoor_Door", gameObject);
                once = false;
            }
            openDoorAnim.Play();
        }

    }
}
