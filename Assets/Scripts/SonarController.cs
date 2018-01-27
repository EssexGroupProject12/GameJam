using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarController : MonoBehaviour
{
    

	public GameObject PlayerGameObject;
	private float offset;
	private Vector2 SonarPos;
    private Vector3 currentScale;
    private float powerModifier;

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
	    if (coll.gameObject.tag == "EncapsulatedObject")
	    {
	        
                coll.GetComponent<EncapsulatedObject>().UpdateVisability();
            
            
	        
	    }
	}


	void UpdatePos()
	{
		offset = this.transform.localScale.y/2 + PlayerGameObject.GetComponent<Renderer>().bounds.size.x / 2;
		SonarPos = new Vector2(PlayerGameObject.transform.position.x + offset, PlayerGameObject.transform.position.y-0.4f);
		this.transform.position = SonarPos;
	}


    public void SonarPowers(bool powerUpDown) // true means up
    {
        currentScale = this.transform.localScale;
        if (powerUpDown)
        {
            powerModifier = 1.25f;
        }
        else
        {
            powerModifier = 0.8f;
        }

        this.transform.localScale = new Vector3(this.transform.localScale.x * powerModifier, this.transform.localScale.y * powerModifier, this.transform.localScale.z);
        Invoke("ResetSonarPowers", 3f);
    }


    public void ResetSonarPowers()
    {
        this.transform.localScale = currentScale;
    }
}
