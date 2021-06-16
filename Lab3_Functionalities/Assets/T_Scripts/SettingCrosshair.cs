using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCrosshair : MonoBehaviour
{
    private Image Crosshair;
    private GameManager GM;
    public Sprite Normal;
    public Sprite TF2;

    // Start is called before the first frame update
    void Start()
    {
        Crosshair = GetComponent<Image>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (PlayerPrefs.HasKey("CrossHair"))
        {
            if (PlayerPrefs.GetInt("CrossHair") == 1)
            {
                Crosshair.sprite = Normal;
            }
            if (PlayerPrefs.GetInt("CrossHair") == 2)
            {
                Crosshair.sprite = TF2;
            }
        }
        else
        {
            Crosshair.sprite = Normal;
            PlayerPrefs.SetInt("CrossHair", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("CrossHair"))
        {
            if (PlayerPrefs.GetInt("CrossHair") == 1)
            {
                Crosshair.sprite = Normal;
            }
            if (PlayerPrefs.GetInt("CrossHair") == 2)
            {
                Crosshair.sprite = TF2;
            }
        }
        else
        {
            Crosshair.sprite = Normal;
            PlayerPrefs.SetInt("CrossHair", 1);
        }
    }
    public void SetCrosshair(int idx)
    {
        PlayerPrefs.SetInt("CrossHair", idx);
        GM.Menu();
    }
}
