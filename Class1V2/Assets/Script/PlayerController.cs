using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 20.0f;
    public float TurnSpeed = 55.0f;
    private float horizontalInput;
    private float forwardInput;
    // Update is called once per frame
    void Update()
    {
        //Imputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Movement of "CarTaxi" in vertical
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * forwardInput);
        //Rotation of "CarTaxi" in horizontal
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * horizontalInput);
    }
}
