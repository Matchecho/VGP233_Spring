using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float Speed = 30.0f;
    private PlayerController PCScript;
    private float LeftBoundary = -15.0f;

    private void Start()
    {
        PCScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (PCScript.GameOver == false)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }

        if (transform.position.x < LeftBoundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
