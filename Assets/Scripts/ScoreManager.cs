using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    private int score = 0;
    private int highscore = 0;

    void Start()
    {
        // Load the high score from PlayerPrefs
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateScore(0); // Initialize score display
    }

    public void UpdateScore(int newScore)
    {
        score = newScore;

        // Ensure Text components are assigned before updating text
        if (scoreText != null)
        {
            scoreText.text = score.ToString() + " Points";
        }
        else
        {
            Debug.LogError("Score Text is not assigned.");
        }

        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
        else
        {
            Debug.LogError("Highscore Text is not assigned.");
        }

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save(); // Ensure the high score is saved
        }
    }
}