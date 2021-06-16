using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float Boundary = 68.0f;
    private GameManager GM;
    private Animator PeopleAnimator;
    private Target Tar;
    private float speed = 0.0f;
    public bool GoingRight = true;
    public bool StaticStand = true;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            Tar = GetComponent<Target>();
            StaticStand = false;
        }
        else if (gameObject.CompareTag("Target"))
        {
            PeopleAnimator = GetComponent<Animator>();
            Tar = GetComponent<Target>();
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
        if (gameObject.CompareTag("Target") && Tar.isAlive)
        {
            speed = 0.5f;
            PeopleAnimator.SetFloat("Speed_f", speed);
            PeopleAnimator.SetBool("Static_b", false);
            StaticStand = false;
        }
        if (gameObject.CompareTag("Target") && !Tar.isAlive)
        {
            speed = 0.0f;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);        
        if (transform.position.x > Boundary || transform.position.x < -Boundary)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("People") && !gameObject.CompareTag("Road"))
        {
            Animator Anim = gameObject.GetComponent<Animator>();
            Animator Anim2 = collision.gameObject.GetComponent<Animator>();
            Anim.SetBool("Death_b", true);
            Anim.SetInteger("DeathType_int", Random.Range(1, 3));
            Anim2.SetBool("Death_b", true);
            Anim2.SetInteger("DeathType_int", Random.Range(1, 3));
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
    }
}
