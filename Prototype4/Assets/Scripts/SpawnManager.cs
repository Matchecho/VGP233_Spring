using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 5.0f;
    // Start is called before the first frame update
    void Start()
    {      
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = 2.5f;
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
