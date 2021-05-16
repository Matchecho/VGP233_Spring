using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInnocetns : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        if (gameObject.CompareTag("Target"))
        {
            Anim.SetInteger("Animation_int", 3);
        }
        else
        {
            int RandAnimation = Random.Range(1, 9);
            Anim.SetInteger("Animation_int", RandAnimation);
        }     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
