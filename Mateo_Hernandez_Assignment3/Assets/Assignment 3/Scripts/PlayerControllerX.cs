using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;
    public float floatForce;
    public float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private float DelayofJump = 0.0f;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip BoingSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        // Apply a small upward force at the start of the game        
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && DelayofJump <= 0.0f)
        {
            playerRb.AddForce(Vector3.up * floatForce * 1.5f, ForceMode.Impulse);
            DelayofJump = 30.0f;
        }
        if (DelayofJump > 0.0f)
        {
            DelayofJump--;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            gameOver = true;
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound);           
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground") && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * floatForce * 2.0f, ForceMode.Impulse);
            playerAudio.PlayOneShot(BoingSound);
        }
        else if (other.gameObject.CompareTag("Roof") && gameOver == false)
        {
            playerRb.AddForce(Vector3.down * floatForce / 3.0f, ForceMode.Impulse);
            playerAudio.PlayOneShot(BoingSound);
        }

        else
        {

        }

    }

}
