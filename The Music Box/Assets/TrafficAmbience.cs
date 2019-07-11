using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficAmbience : MonoBehaviour {

    public AK.Wwise.Event soundSource;
    public GameObject PlayerReference;

	// Use this for initialization
	void Start () {
        soundSource.Post(gameObject);
        PlayerReference = GameObject.FindWithTag("Player");
	}

    void Update()
    {
        transform.position = new Vector3(PlayerReference.transform.localPosition.x, transform.position.y, transform.position.z);
    }

}
