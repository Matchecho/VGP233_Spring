using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject Player;
    private Rigidbody EnemyRB;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRB.AddForce((Player.transform.position - transform.position).normalized * speed);
    }
}
