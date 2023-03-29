using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
// Total time for the countdown
    private float timeLeft = 10.0f;  // Time left for the countdown
    public TextMeshProUGUI countdownText; // Text component to display the countdown
    GameManagerX gameManagerX;

    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

    }
        


    void Update()
    {
    }
    public void timer()
    {
        timeLeft -= Time.deltaTime; // Reduce the time left by the time since the last frame

        // Update the countdown text to display the remaining time
        countdownText.text = "Time Left: " + Mathf.RoundToInt(timeLeft).ToString();

        // If the timer has reached zero, do something (e.g. end the game)
        if (timeLeft <= 0.0f)
        {
            gameManagerX.GameOver();
        }
    }
}
