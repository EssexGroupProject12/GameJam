using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float Speed;

    private void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(Speed, 0);
    }
}
