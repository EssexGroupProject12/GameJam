using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBybound : MonoBehaviour {

	void  OnTriggerEnter2D(Collider2D coll){
		//Debug.Log("touch");
		if (coll.gameObject.tag == "boundary") {
			Destroy (gameObject);
		}
     }
}
