using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public GameObject[] Collectables = new GameObject[2];
    public GameObject Chosen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Chosen = Collectables[Random.Range(0, Collectables.Length)];
        }
    }
}
