using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectDetection : MonoBehaviour {

	public GameObject playerObject;
    private bool isDetecting;
    private bool mouseDownPress;

    private Color mainColor;
    private Color mouseOverColour;

    public RawImage handOverImage;


    // Use this for initialization
    void Start () {
        playerObject = GameObject.FindWithTag("Player");

        mainColor = handOverImage.color;
        mouseOverColour = new Color(0.5f, 0.5f, 0.5f);

	}

	// Update is called once per frame
	void Update () {
        isDetecting = playerObject.GetComponent<PlayerController>().mouseOverObject;

        if (isDetecting)
        {
            handOverImage.CrossFadeAlpha(1, 0.1f, false);
            //print("Object Detection from other script working");
            if (Input.GetMouseButton(0)) { 
                handOverImage.CrossFadeColor(mouseOverColour, 0.05f, false, false);
                mouseDownPress = true;
            }
            else { 
                handOverImage.CrossFadeColor(mainColor, 0.05f, false, false);
                mouseDownPress = false;
            }
        }
        else
        {
            handOverImage.CrossFadeAlpha(0, 0.1f, false);
            mouseDownPress = false;
        }
    }
   
    //getters
    public bool GetMouseDownBool() { return mouseDownPress; }


}
