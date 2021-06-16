using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProfile : MonoBehaviour
{
    // Start is called before the first frame update
    private Wanted[] TheWanted;
    public Image ProfilePic;
    void Start()
    {
        ChangeTarget();
    }

    public void ChangeTarget()
    {
        TheWanted = GameObject.FindObjectsOfType<Wanted>();
        int RandomIdx = UnityEngine.Random.Range(0, TheWanted.Length);
        ProfilePic.sprite = TheWanted[RandomIdx].WantedSprite;
        TheWanted[RandomIdx].isTarget = true;
    }
}
