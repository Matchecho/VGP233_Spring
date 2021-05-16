using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody PlayerRB;
    public GameObject FocusPoint;
    public float speed = 5.0f;
    private float forwardInput;
    private Vector3 speeo;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        FocusPoint = GameObject.Find("FocusPoint");
        
    }

    private void FixedUpdate()
    {
        forwardInput = Input.GetAxis("Vertical");
        PlayerRB.AddForce(FocusPoint.transform.forward * speed * forwardInput);
    }
}
