using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;
    public Text ScoreText;

    public GameObject[] Collectables;
    public GameObject Chosen;

    private void Start()
    {
        StartCoroutine(Spawn());

    }

    private void Update()
    {
        ScoreText.text = string.Format("Score: {0}", Score);
        
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Chosen = Collectables[Random.Range(0, Collectables.Length)];
            Instantiate(Chosen, new Vector3(8, Random.Range(-3, 3), 0), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
        
    }
}
