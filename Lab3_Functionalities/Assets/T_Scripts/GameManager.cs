using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject SettingsScreen;
    public GameObject LoadScreen;
    public GameObject GameScreen;
    public GameObject EndScreen;
    public GameObject ExitScreen;
    public GameObject[] MovingObj;
    public AudioClip SelectSound;
    public AudioClip PlaySound;
    public AudioClip GameOverSound;
    public AudioClip Theme;
    public AudioClip CriticalHit;
    public TextMeshProUGUI BulletText;
    public TextMeshProUGUI TargetkillText;

    private Vector3 SpawnPostion = new Vector3(0.0f, 0.7f, 0.0f);
    private float StartDelay = 3.0f;
    private float Rate = 5.0f;
    private int Bullets = 11;
    private int TargetsKill = 0;
    private AudioSource AudioSour;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        AudioSour = GetComponent<AudioSource>();
        Menu();        
    }
    private void Update()
    {
        if (!AudioSour.isPlaying && isGameActive)
        {
            AudioSour.PlayOneShot(Theme);
        }
    }
    public void Menu()
    {
        AudioSour.PlayOneShot(SelectSound);
        StartScreen.SetActive(true);
        GameScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        LoadScreen.SetActive(false);
        EndScreen.SetActive(false);
        ExitScreen.SetActive(false);
        isGameActive = false;
    }
    public void StartGame()
    {
        UpdateBullets(0);
        UpdateKilled(0);
        AudioSour.Stop();
        AudioSour.PlayOneShot(PlaySound);
        AudioSour.PlayOneShot(Theme);
        StartScreen.SetActive(false);
        GameScreen.SetActive(true);
        SettingsScreen.SetActive(false);
        LoadScreen.SetActive(false);
        EndScreen.SetActive(false);
        ExitScreen.SetActive(false);
        isGameActive = true;
        Rate = Random.Range(3.0f, 8.0f);        
        InvokeRepeating("SpawnObstacle", StartDelay, Rate);
    }

    public void Load()
    {
        AudioSour.PlayOneShot(SelectSound);
        StartScreen.SetActive(false);
        GameScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        LoadScreen.SetActive(true);
        EndScreen.SetActive(false);
        ExitScreen.SetActive(false);
        isGameActive = false;
    }
    
    public void Settings()
    {
        AudioSour.PlayOneShot(SelectSound);
        StartScreen.SetActive(false);
        GameScreen.SetActive(false);
        SettingsScreen.SetActive(true);
        LoadScreen.SetActive(false);
        EndScreen.SetActive(false);
        ExitScreen.SetActive(false);
        isGameActive = false;
    }
    
    public void UpdateBullets(int i)
    {
        if (Bullets < 1)
        {
            GameOver();
        }
        Bullets -= i;
        BulletText.text = " " + Bullets;
               
    }
    public void UpdateKilled(int i)
    {       
        TargetsKill += i;
        BulletText.text = " " + TargetsKill;
    }
    public void Exit()
    {
        AudioSour.PlayOneShot(SelectSound);
        StartScreen.SetActive(false);
        GameScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        LoadScreen.SetActive(false);
        EndScreen.SetActive(false);
        ExitScreen.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        UpdateKilled(0);
        AudioSour.Stop();
        AudioSour.PlayOneShot(GameOverSound);
        StartScreen.SetActive(false);
        GameScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        LoadScreen.SetActive(false);
        EndScreen.SetActive(true);
        isGameActive = false;
    }
    private void SpawnObstacle()
    {
        int index = Random.Range(0, MovingObj.Length);
        int Rightorleft = Random.Range(0, 2);
        if (MovingObj[index].CompareTag("Car") && isGameActive)
        {
            if (Rightorleft == 0)
            {
                SpawnPostion.x = -66.0f;
                SpawnPostion.z = -80.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = true;
            }
            else
            {
                SpawnPostion.x = 66.0f;
                SpawnPostion.z = -74.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = false;
            }
        }
        else if (MovingObj[index].CompareTag("People") && isGameActive)
        {
            SpawnPostion.y = 0.88f;
            if (Rightorleft == 0)
            {
                SpawnPostion.x = -66.0f;
                SpawnPostion.z = -67.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = true;
            }
            else
            {
                SpawnPostion.x = 66.0f;
                SpawnPostion.z = -63.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = false;
            }
        }

        Instantiate(MovingObj[index], SpawnPostion, MovingObj[index].transform.rotation);
    }
}
