using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncapsulatedObject : MonoBehaviour {
    public GameObject main;
    public GameObject fakeObject1;
    public GameObject fakeObject2;
    private float visableSpeed = 0.005f;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AssignObjects(GameObject main, GameObject fakeObject1, GameObject fakeObject2)
    {
        this.main = main;
        this.fakeObject1 = fakeObject1;
        this.fakeObject2 = fakeObject2;
    }

    public void OnDestroy()
    {
        if (main != null)
        {
            Destroy(main);
        }
        if (fakeObject1 != null)
        {
            Destroy(fakeObject1);
        }
        if (fakeObject2 != null)
        {
            Destroy(fakeObject2);
        }
    }

    public void SetEncapsulatedObject()
    {
        // Max alpha is 255 
        main.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0.2f);
        fakeObject1.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0.45f);
        fakeObject2.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0.65f);
    }

    public void UpdateVisability()
    {
        if (main != null)
        {
            var colorMain = main.GetComponent<SpriteRenderer>().color;
            colorMain.a += visableSpeed;
            main.GetComponent<SpriteRenderer>().color = colorMain;

            if (fakeObject1 != null)
            {
                var colorFake1 = fakeObject1.GetComponent<SpriteRenderer>().color;
                colorFake1.a -= visableSpeed;
                fakeObject1.GetComponent<SpriteRenderer>().color = colorFake1;
            }

            if (fakeObject2 != null)
            {
                var colorFake2 = fakeObject2.GetComponent<SpriteRenderer>().color;
                colorFake2.a -= 2 * visableSpeed;
                fakeObject2.GetComponent<SpriteRenderer>().color = colorFake2;
            }
        }
        else
        {
            if (fakeObject1 != null)
            {
                //var colorFake1 = fakeObject1.GetComponent<SpriteRenderer>().color;
                //colorFake1.a = 0;
                //fakeObject1.GetComponent<SpriteRenderer>().color = colorFake1;
                Destroy(fakeObject1);
            }

            if (fakeObject2 != null)
            {
                //var colorFake2 = fakeObject2.GetComponent<SpriteRenderer>().color;
                //colorFake2.a = 0;
                //fakeObject2.GetComponent<SpriteRenderer>().color = colorFake2;
                Destroy(fakeObject2);
            }
        }
    }
}
