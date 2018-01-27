using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;
    public Text ScoreText;

    public GameObject[] Collectables = new GameObject[2];
    public GameObject Chosen;

    private void Start()
    {
        masadhfsaldfghkjsagdlsagdlfsahfhsa
            sadfa;
        sjhdfhsadl;
        fsa
            dfsialohdfil;
    }

    private void Update()
    {
        ScoreText.text = string.Format("Score: {0}", Score);
    }

    private IEnumerator Spawn()
    {
            yield return new WaitForSeconds(2);
            Chosen = Collectables[Random.Range(0, Collectables.Length)];
    }
}
