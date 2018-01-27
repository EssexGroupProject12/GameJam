using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarController : MonoBehaviour
{
    

	public GameObject PlayerGameObject;
	private float offset;
	private Vector2 SonarPos;

	// Use this for initialization
	void Start ()
	{
		UpdatePos();


    }

    // Update is called once per frame
    void Update () {
		UpdatePos();
	}

	void OnTriggerStay2D(Collider2D coll)
	{
	    if (coll.gameObject.tag != "Sonar")
	    {
	        if (coll.gameObject.activeSelf)
	        {
                coll.GetComponent<Mover>().UpdateVisability();
            }
            
	        
	    }
	}


	void UpdatePos()
	{
		offset = this.transform.localScale.y/2 + PlayerGameObject.GetComponent<Renderer>().bounds.size.x / 2 + 0.1f;
		SonarPos = new Vector2(PlayerGameObject.transform.position.x + offset, PlayerGameObject.transform.position.y);
		this.transform.position = SonarPos;
	}


    
}
