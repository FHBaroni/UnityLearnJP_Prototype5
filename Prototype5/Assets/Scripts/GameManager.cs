using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pausedText;
    public Image pauseImage;


    public bool isGameActive;
    public bool isPaused = false;
    public Button restartButton;
    public int lives = 3;
    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            livesText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
        }
        else
        {
            livesText.gameObject.SetActive(false);           
            scoreText.fontSize = 50;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

     void TogglePause()
    {
        if (Time.timeScale > 0 )
        {
            Time.timeScale = 0;
            pausedText.gameObject.SetActive(true);
            pauseImage.gameObject.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pausedText.gameObject.SetActive(false);
            pauseImage.gameObject.SetActive(false);
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);  
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }


    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /=  difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives();
        
        titleScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(false);
    }

    public void UpdateLives()
    {
        livesText.text = "lives: "+ lives;
    }
}
