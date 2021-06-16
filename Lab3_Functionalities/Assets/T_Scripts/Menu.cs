using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Button boton;
    private GameManager GM;
    public int Var;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        boton = GetComponent<Button>();
        GM.Menu();
        boton.onClick.AddListener(SetMode);
    }

    // Update is called once per frame
    public void SetMode()
    {
        switch (Var)
        {
            case 1:
                GM.StartGame();
                break;
            case 2:
                GM.Load();
                break;
            case 3:
                GM.Settings();
                break;
            case 4:
                GM.Exit();
                break;
            default:
                break;
        }
    }
}
