﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -41;
    private float bottomLimit = -2;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit || transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        } 
     

    }
}
