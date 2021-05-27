using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager GameMg;
    private Rigidbody TargetRB;
    private float minSpeed = 12.0f;
    private float MaxSpeed = 16.0f;
    private float MaxTorque = 10.0f;
    private float Xrange = 4.0f;
    private float YSpawnPos = -6.0f;

    public int PointValue;
    public ParticleSystem ExplosiveParticle;
    // Start is called before the first frame update
    void Start()
    {
        GameMg = GameObject.Find("GameManager").GetComponent<GameManager>();
        TargetRB = GetComponent<Rigidbody>();
        TargetRB.AddForce(RandForce(), ForceMode.Impulse);
        TargetRB.AddTorque(RandTorque(), RandTorque(), RandTorque(), ForceMode.Impulse);
        transform.position = RandSpawnPos();
    }

    Vector3 RandForce()
    {
        return Vector3.up * Random.Range(minSpeed, MaxSpeed);
    }

    float RandTorque()
    {
        return Random.Range(-MaxTorque, MaxTorque);
    }

    Vector3 RandSpawnPos()
    {
        return new Vector3(Random.Range(-Xrange, Xrange), YSpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            GameMg.GameOver();
        }
    }

    private void OnMouseDown()
    {
        if (GameMg.IsGameActive)
        {
            Destroy(gameObject);
            GameMg.Updatescore(PointValue);
            Instantiate(ExplosiveParticle, transform.position, ExplosiveParticle.transform.rotation);
            if (GameMg.GetScore() < 0)
            {
                GameMg.GameOver();
            }
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target tg = collision.gameObject.GetComponent<Target>();
        if(tg != null)
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
