using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Padding;

    private float XMin;
    private float XMax;
    private float YMin;
    private float YMax;
    private Rigidbody2D Rigidbody;
    private SpriteRenderer SpriteRenderer;

    private float OriginalSpeed;
    private Color OriginalColor;
    private float SpeedDownRemaining;

    private void Start()
    {
        OriginalSpeed = Speed;
        Rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        OriginalColor = SpriteRenderer.color;
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        var topmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        XMin = leftmost.x + Padding;
        XMax = rightmost.x - Padding;
        YMin = leftmost.y + Padding;
        YMax = topmost.y - Padding;
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var speedVector = new Vector3(horizontalInput * Speed, verticalInput * Speed, 0);
        Rigidbody.velocity = speedVector;

        transform.position = new Vector3(Mathf.Clamp(Rigidbody.position.x, XMin, XMax), Mathf.Clamp(Rigidbody.position.y, YMin, YMax), 0);

        if (SpeedDownRemaining > 0)
        {
            SpeedDownRemaining -= Time.deltaTime;
            if (SpeedDownRemaining <= 0) ResetSpeed();
        }
    }

    public void ChangeSpeedTemporarily()
    {
        Speed = OriginalSpeed - 2.5f;
        SpeedDownRemaining = 3f;
        SpriteRenderer.color = Color.black;
        //Invoke("ResetSpeed", 3f);
    }

    private void ResetSpeed()   
    {
        Speed = OriginalSpeed;
        SpriteRenderer.color = OriginalColor;
    }
}
