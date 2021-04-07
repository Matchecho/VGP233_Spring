using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Running from start method");
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * 15);
    }
}
