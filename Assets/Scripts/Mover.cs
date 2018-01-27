using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float Speed;
    public float r, g, b;


    private void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(Speed, 0);
     
        // Max alpha is 255 
        r = this.GetComponent<Renderer>().material.color.r;
        g = this.GetComponent<Renderer>().material.color.g;
        b = this.GetComponent<Renderer>().material.color.b;

        this.GetComponent<Renderer>().material.color = new Color(r, g, b);
    }

    private void UpdateVisability()
    {
        //When ship sonar is on this object
        var color = this.GetComponent<Renderer>().material.color.a;
        color++;
        this.GetComponent<Renderer>().material.color = new Color(r,g,b, color);
    }

}
