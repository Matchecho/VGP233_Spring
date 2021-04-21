using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMoveObjects : MonoBehaviour
{
    private float zTopBoundary = 25.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zTopBoundary || transform.position.z < -zTopBoundary)
        {
            Destroy(gameObject);
        }
    }
}
