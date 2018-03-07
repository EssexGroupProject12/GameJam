using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timetext;
    public int countdown;
    private GameController gameController;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Counter());
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        timetext.text = string.Format("Timer: " + countdown);
    }

    IEnumerator Counter()
    {
        while (countdown > 0)
        {
            Debug.Log(countdown--);
            yield return new WaitForSeconds(1);
        }

        PlayerSettings.LastScore = gameController.Score;
        SceneManager.LoadScene("Education");
    }
}
