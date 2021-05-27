using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public GameObject TitleScreen;
    public Button RestartButton;
    public bool IsGameActive;

    private float SpawnRate = 1.0f;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        RestartButton.onClick.AddListener(Sendmessage);
    }

    void Sendmessage()
    {
        Debug.Log("Hello");
    }

    public void StartGame(int dif)
    {
        SpawnRate /= dif;
        TitleScreen.SetActive(false);
        IsGameActive = true;
        Score = 0;
        StartCoroutine(SpawnTarget());
        Updatescore(0);       
    }

    IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);           
        }
    }

    public void Updatescore(int scoretoAdd)
    {
        Score += scoretoAdd;
        ScoreText.text = "Score: " + Score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        IsGameActive = false;
    }

    public int GetScore()
    {
        return Score;
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);
    }
}
