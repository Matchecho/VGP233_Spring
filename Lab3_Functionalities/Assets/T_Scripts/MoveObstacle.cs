using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float Boundary = 68.0f;
    private PlayerController PCscript;
    private Animator PeopleAnimator;
    private float speed = 0.0f;
    public bool GoingRight = true;
    public bool StaticStand = true;
    // Start is called before the first frame update
    void Start()
    {
        PCscript = GameObject.Find("Player").GetComponent<PlayerController>();
        if (gameObject.CompareTag("Car"))
        {
            speed = Random.Range(30.0f, 100.0f);
        }
        else if (gameObject.CompareTag("People"))
        {
            PeopleAnimator = GetComponent<Animator>();
            speed = Random.Range(0.3f, 0.8f);
            PeopleAnimator.SetFloat("Speed_f", speed);
            PeopleAnimator.SetBool("Static_b", false);
            StaticStand = false;
        }
        if (GoingRight)
        {
            transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        }
        else
        {
            transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
        }        
    }

    // Update is called once per frame
    void Update()
    {       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);        
        if (transform.position.x > Boundary || transform.position.x < -Boundary)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("People") && gameObject.CompareTag("People"))
        {
            if(StaticStand)
            {
                speed = Random.Range(0.3f, 0.8f);
                PeopleAnimator.SetInteger("Animation_int", 0);
                PeopleAnimator.SetBool("Static_b", false);
                PeopleAnimator.SetFloat("Speed_f", speed);                
                StaticStand = false;
                MoveObstacle OtherMove = collision.gameObject.GetComponent<MoveObstacle>();
                Animator OtherAnim = collision.gameObject.GetComponent<Animator>();
                OtherMove.speed = 0.0f;                
                OtherAnim.SetFloat("Speed_f", 0.0f);
                OtherAnim.SetBool("Static_b", true);
                PeopleAnimator.SetInteger("Animation_int", 1);
                OtherMove.StaticStand = true;
            }
            else
            {
                speed = 0.0f;
                PeopleAnimator.SetFloat("Speed_f", 0.0f);
                PeopleAnimator.SetBool("Static_b", true);
                PeopleAnimator.SetInteger("Animation_int", 1);
                StaticStand = true;
                MoveObstacle OtherMove = collision.gameObject.GetComponent<MoveObstacle>();
                Animator OtherAnim = collision.gameObject.GetComponent<Animator>();
                OtherMove.speed = Random.Range(0.3f, 0.8f);
                PeopleAnimator.SetInteger("Animation_int", 0);
                OtherAnim.SetBool("Static_b", false);
                OtherAnim.SetFloat("Speed_f", speed);                             
                OtherMove.StaticStand = false;
            }
            
        }
    }
}
