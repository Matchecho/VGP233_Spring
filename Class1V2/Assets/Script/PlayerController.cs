using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Running from Start Method");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        transform.Translate(Vector3.forward * Time.deltaTime * 15);
    }
}
