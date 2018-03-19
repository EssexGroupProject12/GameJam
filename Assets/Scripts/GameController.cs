using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public Image GameOverImage;

    public GameObject[] Collectables;
    public GameObject EncapsulatedObject;
    public PlayerController PlayerController { get; private set; }
    private int SpawnRange;
    private int minSpeed = -3, maxSpeed = -1;
    public bool sub = true;

    private void Start()
    {
        StartCoroutine(Spawn());
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        SpawnRange = 94;
    }

    private void Update()
    {
        ScoreText.text = string.Format("Score: {0}", Score);
    }


    private IEnumerator Spawn()
    {
        while (true)
        {
            var pos = new Vector3(8, Random.Range(-7, 3) / 2, 0);
            if (sub)
            {
                pos = new Vector3(8, Random.Range(-3, 3), 0);
            }
            
            var encap = Instantiate(EncapsulatedObject, pos, Quaternion.identity);
            var encapsulatedObject = encap.GetComponent<EncapsulatedObject>();
            var main = Collectables[SpawnRates(false)];
            var speed = Random.Range(minSpeed, maxSpeed);
            encap.GetComponent<Mover>().Speed = speed;
            main.GetComponent<Mover>().Speed = speed;
            
            encapsulatedObject.main = Instantiate(main, pos, Quaternion.identity);
            
           
            for (int i = 0; i < 2; i++)
            {
                var fakeObject = Collectables[SpawnRates(true)];
                fakeObject.GetComponent<Mover>().Speed = speed;
                var fakeInstance = Instantiate(fakeObject, pos, Quaternion.identity);
                fakeInstance.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                //fakeInstance.gameObject.GetComponent<AudioSource>().enabled = false;
                if (i == 0) encapsulatedObject.fakeObject1 = fakeInstance;
                else encapsulatedObject.fakeObject2 = fakeInstance;
            }
            encapsulatedObject.SetEncapsulatedObject();

            yield return new WaitForSeconds(2);
        }
        
    }

    private int SpawnRates(bool fake)
    {

        int RandomChoice = Random.Range(0, SpawnRange);

        if (RandomChoice < 15) return 1; //coin
        if (RandomChoice >= 15 && RandomChoice <25) return 0; //chest
        if (RandomChoice >= 25 && RandomChoice <34) return 3; //sonar buff
        if (RandomChoice >= 34 && RandomChoice <39 ) return 2;//clam
        if (RandomChoice >= 39 && RandomChoice <44 ) return 5;// damage mine
        if (RandomChoice >= 44 && RandomChoice <53 ) return 6;//emp mine
        if (RandomChoice >= 53 && RandomChoice <61 ) return 9;//time cutter
        if (RandomChoice >= 61 && RandomChoice <77 ) return 8;//shoe
        if (RandomChoice >= 77 && RandomChoice < 93) return 7;//shark
        if (RandomChoice == 94)
        {
            if (!fake) SpawnRange = 93;//trident
            return 4;
        }
        return 1; //default coin (but should never get here)
    }

    public void EndGame()
    {
        GameOverImage.gameObject.SetActive(true);
        PlayerController.Speed = 0;
        PlayerController.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        var hook = GameObject.FindGameObjectWithTag("Hook");
        if (hook != null)
        {
            hook.GetComponent<PolygonCollider2D>().enabled = false;
        }
        StopAllCoroutines();
        Invoke("ShowEducationScreen", 2);
    }

    private void ShowEducationScreen()
    {
        SceneManager.LoadScene("Education");
    }
}
