using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuACHT : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("BasicGameMenu");
    }

    public void QuitGame()
    {
        Debug.Log("You left the game.");
        Application.Quit();
    }

}
