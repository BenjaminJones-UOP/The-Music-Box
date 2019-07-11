using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorScript : MonoBehaviour {

    public PlayerController playerControllerScript;

    bool once;

    // Use this for initialization
    void Start()
    {
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.GetBedroomDoorKey())
        {

            if (once)
            {
                AkSoundEngine.PostEvent("GeneratorTurnOff", gameObject);
                AkSoundEngine.SetState("TaskController", "Task2_BathOn");
                AkSoundEngine.PostEvent("Pick_Up_Key", GameObject.FindWithTag("Player"));
                once = false;
            }
        }
    }
}