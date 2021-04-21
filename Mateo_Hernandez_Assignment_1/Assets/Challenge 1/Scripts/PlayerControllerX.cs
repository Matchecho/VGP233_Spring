using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotationSpeed = 0.0f;
    private float verticalInput;
    public GameObject projectilePrefab;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vertical Input of plane by Mateo
        verticalInput = Input.GetAxis("Vertical");

        //Constant Speed of Plane moving forward by Mateo
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Player control velocity up and down by Mateo
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime * verticalInput);
    }
}
