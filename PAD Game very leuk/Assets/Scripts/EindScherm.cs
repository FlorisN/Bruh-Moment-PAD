using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EindScherm : MonoBehaviour
{
    public void VerliesScherm()
    {
        SceneManager.LoadScene("VerliesScherm");
    }

    public void WinScherm()
    {
        SceneManager.LoadScene("WinScherm");
    }
}

