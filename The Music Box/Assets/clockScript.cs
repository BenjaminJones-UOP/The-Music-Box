using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockScript : MonoBehaviour {

    public PlayerController playerControllerScript;

    bool once;

    // Use this for initialization
    void Start () {
        once = true;
        AkSoundEngine.PostEvent("Clock_Ticking", gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        if (playerControllerScript.GetBackDoorKey()) 
        {
            //stop clock music
            if (once)
            {
                AkSoundEngine.PostEvent("Open_Clock", gameObject);
                AkSoundEngine.PostEvent("Pick_Up_Key", GameObject.FindWithTag("Player"));
                AkSoundEngine.PostEvent("GeneratorOn", GameObject.FindWithTag("Generator"));
                AkSoundEngine.PostEvent("GeneratorTurnOn", GameObject.FindWithTag("Generator"));
                AkSoundEngine.SetState("TaskController", "Task1_GeneratorOn");
                once = false;
            }
        }

    }
}
