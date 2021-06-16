using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100.0f;
    public float fireRate = 15.0f;
    public Camera fpsCamera;
    public GameObject Crosshair;
    public AudioClip Gunshoot;
    public AudioClip Reload;

    private float nextTimeToShoot = 0.0f;
    private GameManager GM;
    private AudioSource AudioSourGun;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        AudioSourGun = GameObject.Find("GameManager").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot && GM.isGameActive)
        {           
            nextTimeToShoot = Time.time + 1.0f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        AudioSourGun.PlayOneShot(Gunshoot);
        AudioSourGun.PlayOneShot(Reload);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            GM.UpdateBullets(1);
            Target target = hit.transform.gameObject.GetComponent<Target>();
            if (target != null)
            {
                target.Kill();
            }
        }
    }
}
