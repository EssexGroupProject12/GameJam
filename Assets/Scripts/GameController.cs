using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;
    public Text ScoreText;

    private void Start()
    {
        
    }

    private void Update()
    {
        ScoreText.text = string.Format("Score: {0}", Score);
    }
}
