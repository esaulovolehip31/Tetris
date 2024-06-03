using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; //ui text for score
    public Text highscoreText; //ui text for highscore

    private int score = 0;
    private int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateScore(0);
    }

    public void UpdateScore(int newScore)
    {
        score = newScore;
        
        if (scoreText != null)
        {
            scoreText.text = score.ToString() + " Points"; //update the score text
        }
        

        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
        

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore); // update the highscore
            PlayerPrefs.Save();// save highscore
        }
    }
}