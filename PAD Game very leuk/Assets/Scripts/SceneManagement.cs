using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // This is the 'Game' scene, it will start the game.
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();             // This will quit the whole application.
    }
}
