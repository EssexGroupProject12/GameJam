using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private FaderScript FaderScript;
    private void Start()
    {
        FaderScript = GetComponent<FaderScript>();
    }
    public void LoadScene(string name)
    {
        StartCoroutine(FadeOut(name));
    }

    public void QuitGame()
    {
        StartCoroutine(FadeOut(null));
    }

    private IEnumerator FadeOut(string name)
    {
        var howLongToWait = FaderScript.BeginFade(1);
        yield return new WaitForSeconds(howLongToWait);
        if (string.IsNullOrEmpty(name))
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }
}
