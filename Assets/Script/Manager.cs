using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void OnReset()
    {
        SceneManager.LoadScene("TestTerrain");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
