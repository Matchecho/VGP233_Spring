using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    private GameObject FocusPoint;
    private float forwardInput;
    private float PowerUpStrenght = 5.0f;
    public float speed = 5.0f;
    public bool Haspowerup = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Haspowerup = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Haspowerup)
        {
            Rigidbody EnemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayfromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            EnemyRb.AddForce(AwayfromPlayer * PowerUpStrenght, ForceMode.Impulse);
        }
    }
}
