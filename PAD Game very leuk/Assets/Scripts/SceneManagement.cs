using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");     // This is the 'Game' scene, it will start the game.
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");     // This is the 'Menu' scene, it will go back to the menu.
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();                 // This will quit the whole application.
    }
}
