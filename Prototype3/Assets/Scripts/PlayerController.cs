using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRigidBody;
    private bool Isonground = true;
    private Animator PlayerAnim;
    private AudioSource AudSource;

    public ParticleSystem ExplosiveParticle;
    public ParticleSystem dirtParticle;
    public float JumpForce;
    public float Gravity;    
    public bool GameOver = false;
    public AudioClip DeathClip;
    public AudioClip JumpClip;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
        Physics.gravity *= Gravity;
        PlayerAnim = GetComponent<Animator>();
        AudSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Isonground && !GameOver)
        {
            PlayerRigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Isonground = false;
            PlayerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            AudSource.PlayOneShot(JumpClip);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Isonground = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            ExplosiveParticle.Play();
            dirtParticle.Stop();
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            AudSource.PlayOneShot(DeathClip);
            Debug.Log("Game Over!");
        }
    }
}
