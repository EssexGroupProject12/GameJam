using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float Speed;

    private void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(Speed, 0);
     
        // Max alpha is 255 
        this.GetComponent<SpriteRenderer>().color =  new Color(255f, 255f, 255f, 0.05f);
    }



    public void UpdateVisability()
    {
        //When ship sonar is on this object
        var color = this.GetComponent<SpriteRenderer>().color;
        color.a += 0.005f;
        this.GetComponent<SpriteRenderer>().color = color;
    }

}
