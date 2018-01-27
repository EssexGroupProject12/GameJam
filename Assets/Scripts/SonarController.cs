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

	void OnTriggerEnter2D(Collider2D coll)
	{
		//this.GetComponent<SpriteRenderer>().color = Color.blue;
	    coll.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	}


	void UpdatePos()
	{
		offset = this.transform.localScale.y/2 + PlayerGameObject.GetComponent<Renderer>().bounds.size.x / 2 + 0.1f;
		SonarPos = new Vector2(PlayerGameObject.transform.position.x + offset, PlayerGameObject.transform.position.y);
		this.transform.position = SonarPos;
	}

	void SonarEffect()
	{

		
	}

}
