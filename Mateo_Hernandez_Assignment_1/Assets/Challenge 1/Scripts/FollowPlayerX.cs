using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 OffSetCamara = new Vector3(16.0f, 2.0f, 0.0f);

    // Update is called once per frame
    void Update()
    {
        //Position transformation of Camara follwing the plane by Mateo
        transform.position = plane.transform.position + OffSetCamara;
    }
}
