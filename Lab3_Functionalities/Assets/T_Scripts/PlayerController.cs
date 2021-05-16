using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    private float DelayofBullet = 0.0f; //Delay of 2.5 seconds
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && DelayofBullet <= 0.0f)
        {
            Instantiate(BulletPrefab, transform.position, BulletPrefab.transform.rotation);
            DelayofBullet = 150.0f;
        }
        if (DelayofBullet > 0.0f)
        {
            DelayofBullet--;
        }
    }
}
