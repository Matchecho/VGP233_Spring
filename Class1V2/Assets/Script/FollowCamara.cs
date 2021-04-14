using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour
{
    public GameObject Player;
    private Vector3 OffSetCamera = new Vector3(0.0f, 1.5f, -3.0f);
    // Update is called once per frame
    void Update()
    {
        //Tracking of Camera to player
        transform.position = Player.transform.position + OffSetCamera;
    }
}
