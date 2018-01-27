using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
    }
    public void LoadScene(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
