using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditscrawl : MonoBehaviour
{
    public int creditsTimer;
	// Use this for initialization
	void Start () {
        StartCoroutine(Counter());
    }
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up*68*Time.deltaTime,Space.World);
	}
    IEnumerator Counter()
    {
        while (creditsTimer > 0)
        {
            creditsTimer--;
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(0);
    }
}
