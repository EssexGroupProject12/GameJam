using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private GameController GameController;
    private GameObject sonar;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sonar = GameObject.FindGameObjectWithTag("Sonar");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            switch (gameObject.tag)
            {
                case "Coin": //coin
                    GameController.Score += 5;
                    break;
                case "Chest": //treasure chest
                    GameController.Score += 10;
                    break;
                case "MineEMP":
                    GameController.PlayerController.ChangeSpeedTemporarily();
                    break;
                case "Shoe": //shoe
                    GameController.Score += 1;
                    break;
                case "Monster":  //shark
                    if (GameController.Score >= 10) GameController.Score -= 10;
                    else GameController.Score = 0;
                    break;
                case "MineDamage":  //damage mine
                    if (GameController.Score >= 5) GameController.Score -= 5;
                    else GameController.Score = 0;
                    break;
                case "SonarBuff":  // power up
                    sonar.GetComponent<SonarController>().SonarPowers(true);
                    break;
                case "SonarDebuff":  // power down
                    sonar.GetComponent<SonarController>().SonarPowers(false);
                    break;
                case "RareItem"://25
                    GameController.Score += 25;
                    break;
                case "UniqueItem"://50
                    GameController.Score += 50;
                    break;
            }

            if (gameObject.GetComponent<AudioSource>() != null)
            {
                AudioSource.PlayClipAtPoint(gameObject.GetComponent<AudioSource>().clip, Camera.main.transform.position);
            }
            Destroy(gameObject);
        }
    }
}
