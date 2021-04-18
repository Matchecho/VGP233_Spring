using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerMove : MonoBehaviour
{
    public float Speed = 0.0f;
    // Update is called once per frame
    void Update()
    {
        //Rotatiom of Propeller by Mateo
        transform.Rotate(Vector3.forward, Speed * Time.deltaTime * 4);
    }
}
