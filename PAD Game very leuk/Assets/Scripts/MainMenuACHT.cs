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
        Application.Quit();
    }

}
