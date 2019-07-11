using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsOccRay : MonoBehaviour {

    Vector3 OriginPoint;
    public GameObject player;
    float distToPlayer;
    float MaxAtt;

    RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        OriginPoint = transform.position;

        MaxAtt = AkSoundEngine.GetMaxRadius(gameObject);

        Vector3 TargetDirection = player.transform.position - transform.position;
        distToPlayer = Vector3.Distance(player.transform.position, OriginPoint);

        float obstructionLevel = Mathf.Round(distToPlayer / MaxAtt * 100.0f) / 100.0f;
        float occlusionLevel = Mathf.Round(distToPlayer / MaxAtt * 100.0f) / 100.0f;

        if(distToPlayer <= MaxAtt)
        {
            Physics.Raycast(OriginPoint, TargetDirection, out hitInfo, distToPlayer);

            //if hitting nothing
            if (hitInfo.collider.tag == "Player") 
            {
                AkSoundEngine.SetObjectObstructionAndOcclusion(gameObject, player, 0.0f, 0.0f);
                Debug.DrawRay(OriginPoint, TargetDirection, Color.blue);
            }

            //if hitting wall
            if(hitInfo.collider.tag == "WallObject")
            {
                AkSoundEngine.SetObjectObstructionAndOcclusion(gameObject, player, 0.6f, 0.7f);
                Debug.DrawRay(OriginPoint, TargetDirection, Color.red);

                Debug.Log(obstructionLevel +" "+ occlusionLevel);
            }
        }
	}
}
