using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float SpawnPosZ = 20.0f;
    private float Xrange = 19.0f;
    private float Delay = 3.0f;
    private float SpawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimalRand", Delay, SpawnInterval);
    }


    private void SpawnAnimalRand()
    {
        int AniIdx = Random.Range(0, 3);
        Vector3 SpawnPos = new Vector3(Random.Range(-Xrange, Xrange), 0, SpawnPosZ);
        Instantiate(animalPrefabs[AniIdx], SpawnPos, animalPrefabs[AniIdx].transform.rotation);
    }
}
