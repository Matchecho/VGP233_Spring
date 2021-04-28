using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float RepeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        RepeatWidth = GetComponent<BoxCollider>().size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - RepeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
