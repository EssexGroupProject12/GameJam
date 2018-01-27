using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditscrawl : MonoBehaviour
{
    public GameObject exit;
    //When the exit object reaches a certain level in the crawl, the crawl ends
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(FadeOut());
	}
	
	// Update is called once per frame
	void Update () {
       
            transform.Translate(Vector3.up * 68 * Time.deltaTime, Space.World);
	}
     IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene(1);
    }
}
