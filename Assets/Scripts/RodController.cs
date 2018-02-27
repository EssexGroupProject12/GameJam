using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodController : MonoBehaviour
{
    private LineRenderer LineRenderer { get; set; }
    private GameObject Player { get; set; }
    private GameObject Hook { get; set; }
    private float MinY { get; set; }
    private Vector3 InitialLinePosition0 { get; set; }
    private Vector3 InitialLinePosition1 { get; set; }
    private Vector3 InitialHookPosition { get; set; }
    private bool RodCastingOff { get; set; }
    private bool RodReelingIn { get; set; }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Hook = GameObject.FindGameObjectWithTag("Hook");
        LineRenderer = GetComponent<LineRenderer>();
        InitialLinePosition0 = LineRenderer.GetPosition(0);
        InitialLinePosition1 = LineRenderer.GetPosition(1);
        InitialHookPosition = Hook.transform.position;

        var distance = transform.position.z - Camera.main.transform.position.z;
        MinY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !RodCastingOff && !RodReelingIn)
        {
            RodCastingOff = true;
        }
        if (RodCastingOff)
        {
            var secondPosition = LineRenderer.GetPosition(1);
            var newPositionVector = new Vector3(InitialLinePosition0.x, secondPosition.y - Time.deltaTime * 2, -1);
            if (newPositionVector.y > MinY)
            {
                LineRenderer.SetPosition(1, newPositionVector);
                Hook.transform.position = newPositionVector;
            }
            else
            {
                RodCastingOff = false;
                RodReelingIn = true;
            }
        }
        if (RodReelingIn)
        {
            var secondPosition = LineRenderer.GetPosition(1);
            var newPositionVector = new Vector3(InitialLinePosition0.x, secondPosition.y + Time.deltaTime * 4, -1);
            if (newPositionVector.y < InitialLinePosition1.y)
            {
                LineRenderer.SetPosition(1, newPositionVector);
                Hook.transform.position = newPositionVector;
            }
            else
            {
                RodCastingOff = false;
                RodReelingIn = false;
            }
        }
    }
}
