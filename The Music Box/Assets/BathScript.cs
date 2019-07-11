using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathScript : MonoBehaviour {

    public PlayerController playerControllerScript;

    bool once;

    // Use this for initialization
    void Start () {
        once = true;
        AkSoundEngine.PostEvent("Bath_Taps", gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        if (playerControllerScript.GetAtticKey()) 
        {
            if (once)
            {
                //AkSoundEngine.SetState("TaskController", "Task3_AllOff");
                once = false;
            }

        }
	}
}