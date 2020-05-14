using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public void YesButton()
    {
        SceneManager.LoadScene("Interaction Scene 1");
    }

    public void NoButton()
    {
        SceneManager.LoadScene("VerliesScherm");
    }
}