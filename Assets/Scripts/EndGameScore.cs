using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScore : MonoBehaviour
{

    private LevelManager levelManager;
    private Text scoreShower;

    // Use this for initialization
    void Start ()
	{
	    levelManager = GetComponent<LevelManager>();
        scoreShower = GetComponent<Text>();
        scoreShower.text = PlayerSettings.LastScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
