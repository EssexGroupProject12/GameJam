using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodController : MonoBehaviour
{
    private LineRenderer LineRenderer { get; set; }
    private GameObject Player { get; set; }
    private PlayerController PlayerController { get; set; }
    private GameObject Hook { get; set; }
    private float MinY { get; set; }
    //private Vector3 InitialLinePosition0 { get; set; }
    //private Vector3 InitialLinePosition1 { get; set; }
    private Vector3 InitialHookPosition { get; set; }
    private bool RodCastingOff { get; set; }
    private bool RodReelingIn { get; set; }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController = Player.GetComponent<PlayerController>();
        Hook = GameObject.FindGameObjectWithTag("Hook");
        LineRenderer = GetComponent<LineRenderer>();
        //InitialLinePosition0 = LineRenderer.GetPosition(0);
        //InitialLinePosition1 = LineRenderer.GetPosition(1);
        InitialHookPosition = Hook.transform.position;

        var distance = transform.position.z - Camera.main.transform.position.z;
        MinY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !RodCastingOff && !RodReelingIn)
        {
            RodCastingOff = true;
            PlayerController.HookActive = true;
            var startPositionVector = new Vector3(Hook.transform.position.x, Hook.transform.position.y + 0.28f, -1);
            LineRenderer.SetPosition(0, startPositionVector);
            LineRenderer.SetPosition(1, startPositionVector);
        }

        if (RodCastingOff)
        {
            var secondPosition = LineRenderer.GetPosition(1);
            var newPositionVector = new Vector3(Hook.transform.position.x, secondPosition.y - Time.deltaTime * 2, -1);
            if (newPositionVector.y > MinY)
            {
                LineRenderer.SetPosition(1, newPositionVector);
                Hook.transform.position = new Vector3(newPositionVector.x, newPositionVector.y - 0.28f, newPositionVector.z);
            }
            else
            {
                RodCastingOff = false;
                RodReelingIn = true;
            }
        }
        else if (RodReelingIn)
        {
            var secondPosition = LineRenderer.GetPosition(1);
            var newPositionVector = new Vector3(Hook.transform.position.x, secondPosition.y + Time.deltaTime * 4, -1);
            if (newPositionVector.y < InitialHookPosition.y)
            {
                LineRenderer.SetPosition(1, newPositionVector);
                Hook.transform.position = newPositionVector;
            }
            else
            {
                RodCastingOff = false;
                RodReelingIn = false;
                PlayerController.HookActive = false;
                LineRenderer.SetPosition(0, new Vector3());
                LineRenderer.SetPosition(1, new Vector3());
            }
        }
    }

    public void ReelRodIn()
    {
        RodCastingOff = false;
        RodReelingIn = true;
    }
}
