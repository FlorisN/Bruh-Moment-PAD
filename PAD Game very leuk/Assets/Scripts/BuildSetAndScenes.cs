using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildSetAndScenes : MonoBehaviour
{

     public void ToSecondInteractionScene()
    {
        SceneManager.LoadScene("Interaction Scene 2");
    }

    public void ToLoseScreen()
    {
        SceneManager.LoadScene("VerliesScherm");
    }

    public void ToWinScreen()
    {
        SceneManager.LoadScene("WinScherm");
    }

    public void ToFirstInteractionScene()
    {
        SceneManager.LoadScene("Interaction Scene 1");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("BasicGameMenu");
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("StartMenu1");
    }

    public void ToNextBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToPreviousBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("You left the game.");
        Application.Quit();
    }
}
