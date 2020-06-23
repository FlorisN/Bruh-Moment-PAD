using System;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public Transform player;
    public Text score;
    public Text highscoreText;

    void Update()
    {

        //When the float that is in the PlayerPrefs is lower than the score right now (player.position.x),
        //then the PlayerPrefs will set the HighScore to score (player.position.x).
        if (PlayerPrefs.GetFloat("HighScore") < player.position.x)
        {
            PlayerPrefs.SetFloat("HighScore", player.position.x);
        }

        //We need to change the text and it has to be a string.
        //The number (player pos x) will be converted to a string with 'ToString()'.
        //There is a zero so it doesn't display any decimals.
        score.text = "SCORE: " + player.position.x.ToString("0");

        highscoreText.text = "HIGHSCORE: " + (int)PlayerPrefs.GetFloat("HighScore");
    }
}
