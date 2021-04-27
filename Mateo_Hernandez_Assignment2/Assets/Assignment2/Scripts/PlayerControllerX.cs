using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float DelayOfDog = 0.0f; //Delay of 2.5 seconds
    // Update is called once per frame
    void Update()
    {        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && DelayOfDog <= 0.0f)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            DelayOfDog = 150.0f;
        }
        if (DelayOfDog > 0.0f)
        {
            DelayOfDog--;
        }        
    }
}
