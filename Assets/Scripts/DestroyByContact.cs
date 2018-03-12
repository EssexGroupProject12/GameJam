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
        var rod = GameObject.FindGameObjectWithTag("Rod");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Hook")
        { 
            switch (gameObject.tag)
            {
                case "Coin":
                case "BananaPeel":
                    GameController.Score += 5;
                    break;
                case "Chest":
                case "Bottle":
                    GameController.Score += 10;
                    break;
                case "MineEMP":
                    GameController.PlayerController.ChangeSpeedTemporarily();
                    Instantiate(gameObject.GetComponent<MineExplosion>().Explosion, gameObject.transform.position, Quaternion.identity);
                    break;
                case "Can":
                    GameController.PlayerController.ChangeSpeedTemporarily();
                    break;
                case "Shoe":
                case "Fish1":
                    GameController.Score += 1;
                    break;
                case "Monster":  //shark
                case "Fish2":
                    if (GameController.Score >= 10) GameController.Score -= 10;
                    else GameController.Score = 0;
                    break;
                case "MineDamage":
                case "Fish3":
                    if (GameController.Score >= 5) GameController.Score -= 5;
                    else GameController.Score = 0;
                    break;
                case "SonarBuff":  // power up
                case "Fish4":
                    sonar.GetComponent<SonarController>().SonarPowers(true);
                    break;
                case "SonarDebuff":  // power down
                case "Fish5":
                    sonar.GetComponent<SonarController>().SonarPowers(false);
                    break;
                case "RareItem":
                case "Fish6":
                    GameController.Score += 25;
                    break;
                case "UniqueItem":
                case "Toothbrush":
                    GameController.Score += 50;
                    break;
            }

            if (gameObject.GetComponent<AudioSource>() != null && gameObject.GetComponent<AudioSource>().clip != null)
            {
                AudioSource.PlayClipAtPoint(gameObject.GetComponent<AudioSource>().clip, Camera.main.transform.position);
            }

            var rod = GameObject.FindGameObjectWithTag("Rod");
            if (rod != null) rod.GetComponent<RodController>().ReelRodIn();

            Destroy(gameObject);
        }
    }
}
