using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float Speed;
    //private float visablespeed = 0.005f;
    //private EncapsulatedObject encapsulatedObject;

    private void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(Speed, 0);
    }

    //public void SetEncapsulatedObject()
    //{
    //    // Max alpha is 255 
    //    encapsulatedObject = GetComponent<EncapsulatedObject>();
    //    encapsulatedObject.main.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0.2f);
    //    encapsulatedObject.fakeObject1.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0.45f);
    //    encapsulatedObject.fakeObject2.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0.55f);
    //}

    //public void UpdateVisability()
    //{
    //    //When ship sonar is on this object
    //    //var color = this.GetComponent<SpriteRenderer>().color;
    //    //color.a += visablespeed;
    //    //this.GetComponent<SpriteRenderer>().color = color;

    //    var colorMain = encapsulatedObject.main.GetComponent<SpriteRenderer>().color;
    //    colorMain.a += visablespeed;
    //    encapsulatedObject.main.GetComponent<SpriteRenderer>().color = colorMain;

    //    var colorFake1 = encapsulatedObject.fakeObject1.GetComponent<SpriteRenderer>().color;
    //    colorFake1.a -= visablespeed;
    //    encapsulatedObject.fakeObject1.GetComponent<SpriteRenderer>().color = colorFake1;

    //    var colorFake2 = encapsulatedObject.fakeObject2.GetComponent<SpriteRenderer>().color;
    //    colorFake2.a -= visablespeed;
    //    encapsulatedObject.fakeObject2.GetComponent<SpriteRenderer>().color = colorFake2;
    //}

}
