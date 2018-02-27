using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarController : MonoBehaviour
{
    

	public GameObject PlayerGameObject;
	private float offset;
	private Vector2 SonarPos;
    private float[] powerModifier = new float[2];
    public bool sub = true;

    // Use this for initialization
    void Start ()
	{
		UpdatePos();
        powerModifier[0] = 1.25f;
        powerModifier[1] = 0.8f;

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
        if (sub)
        {
            offset = this.transform.localScale.y / 2 + PlayerGameObject.GetComponent<Renderer>().bounds.size.x / 2;
            SonarPos = new Vector2(PlayerGameObject.transform.position.x + offset, PlayerGameObject.transform.position.y - 0.4f);
            this.transform.position = SonarPos;
        }
        else
        {
            offset = this.transform.localScale.y / 2 + PlayerGameObject.GetComponent<Renderer>().bounds.size.y / 2;
            SonarPos = new Vector2(PlayerGameObject.transform.position.x, PlayerGameObject.transform.position.y - offset);
            this.transform.position = SonarPos;
        }

		
	}


    public void SonarPowers(bool powerUpDown) // true means up
    {
        
        float powerMult;
        powerMult = powerUpDown ? powerModifier[0] : powerModifier[1];

        this.transform.localScale = new Vector3(this.transform.localScale.x * powerMult, this.transform.localScale.y * powerMult, this.transform.localScale.z);
        if (powerUpDown) Invoke("DownSonarPowers", 5f);
        else Invoke("UpSonarPowers", 5f); ;
        
    }


    public void DownSonarPowers()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x / powerModifier[0], this.transform.localScale.y / powerModifier[0], this.transform.localScale.z);
    }
    public void UpSonarPowers()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x / powerModifier[1], this.transform.localScale.y / powerModifier[1], this.transform.localScale.z);
    }
}
