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
        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 50);
    }

    private void UpdateVisability()
    {
        //When ship sonar is on this object
        var color = this.GetComponent<Renderer>().material.color.a;
        color++;
        this.GetComponent<Renderer>().material.color = new Color(0,0,0, color);
    }

}
