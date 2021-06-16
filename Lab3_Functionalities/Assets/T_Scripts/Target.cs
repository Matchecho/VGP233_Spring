using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Animator Anim;
    private GameManager GM;
    private Wanted Want;
    private ChangeProfile CG;
    private AudioSource AudioSour;
    public GameObject TargetImage;
    public bool isAlive = true;
    void Start()
    {
        Anim = GetComponent<Animator>();       
        Want = GetComponent<Wanted>();
        CG = TargetImage.GetComponent<ChangeProfile>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        AudioSour = GameObject.Find("GameManager").GetComponent<AudioSource>();
    }
    public void Kill()
    {
        //PlayDeath
        isAlive = false;
        Anim.SetBool("Death_b", true);
        Anim.SetInteger("DeathType_int", Random.Range(1, 3));        
        if (Want.isTarget)
        {
            CG.ChangeTarget();
            GM.UpdateKilled(1);
            GM.UpdateBullets(-2);
            AudioSour.PlayOneShot(GM.CriticalHit);
        }
        else
        {
            GM.GameOver();
        }
    }
}
