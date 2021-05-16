using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    private PlayerController PCScript;
    private Vector3 SpawnPos = new Vector3(30.0f, 0.0f, 0.0f);
    private float startDelay = 2.0f;
    private float Rate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, Rate);
        PCScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void SpawnObstacle()
    {
        if (PCScript.GameOver == false)
        {
            Instantiate(ObstaclePrefab, SpawnPos, ObstaclePrefab.transform.rotation);
        }            
    }
    
}
