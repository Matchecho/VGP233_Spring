using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamara : MonoBehaviour
{
    public float rotationspeed;
    private float horizonalimput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizonalimput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.right * rotationspeed * horizonalimput * Time.deltaTime);
    }
}
