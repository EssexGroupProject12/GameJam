using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScore : MonoBehaviour
{
    private Text scoreShower;

    private void Start ()
	{
        scoreShower = GetComponent<Text>();
        scoreShower.text = PlayerSettings.LastScore.ToString();
	}
}
