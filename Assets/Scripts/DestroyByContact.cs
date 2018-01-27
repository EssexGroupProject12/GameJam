using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameController GameController;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            switch (gameObject.tag)
            {
                case "Coin":
                    GameController.Score += 5;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
