using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;
    public Text ScoreText;

    public GameObject[] Collectables;
    public GameObject EncapsulatedObject;
    //public Vector3 pos;

    private void Start()
    {
        StartCoroutine(Spawn());

    }

    private void Update()
    {
        ScoreText.text = string.Format("Score: {0}", Score);
        
    }


    private IEnumerator Spawn()
    {
        while (true)
        {
            var pos = new Vector3(8, Random.Range(-3, 3), 0);
            var encapsulatedObject = Instantiate(EncapsulatedObject, pos, Quaternion.identity).GetComponent<EncapsulatedObject>();
            var main = Collectables[Random.Range(0, Collectables.Length)];
            encapsulatedObject.main = Instantiate(main, pos, Quaternion.identity);
           
            for (int i = 0; i < 2; i++)
            {
                var fakeObject = Collectables[Random.Range(0, Collectables.Length)];
                var fakeInstance = Instantiate(fakeObject, pos, Quaternion.identity);
                fakeInstance.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                if (i == 0) encapsulatedObject.fakeObject1 = fakeInstance;
                else encapsulatedObject.fakeObject2 = fakeInstance;
            }
            encapsulatedObject.SetEncapsulatedObject();

            yield return new WaitForSeconds(2);
        }
        
    }
}
