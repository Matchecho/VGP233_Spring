using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera Cam;
    public GameObject Crosshair;
    public GameObject AssaultRifle;
    public float offsetMouse = 30.0f;
    public AudioSource AudSource;
    // Update is called once per frame
    void Start()
    {
        Cam = Camera.main;
    }
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        Crosshair.transform.position = MousePos;
        MousePos.z = MousePos.z + offsetMouse;
        AssaultRifle.transform.LookAt(Cam.ScreenToWorldPoint(MousePos));  
    }
}
