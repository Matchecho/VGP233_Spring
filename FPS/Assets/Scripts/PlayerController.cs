using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController plController;
    public float gravity = -9.81f;
    public float JumpHeight = 3.0f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float speed = 12.0f;
    bool Isground;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        plController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Isground)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2.0f * gravity);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Isground = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveXZ = transform.right * x + transform.forward * z;
        plController.Move(moveXZ * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        plController.Move(velocity * Time.deltaTime);
    }
}
