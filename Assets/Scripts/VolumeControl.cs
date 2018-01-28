using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    //x stands for the 
    public float volume;
    public GameObject audioObject;
    public Slider slides;
    // Use this for initialization
    void Awake()
    {
        volume = 50.0f;
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void OnGUI()
    {

        volume = slides.value;
        

        audioObject.GetComponent<AudioSource>().volume = volume;
    }
    void Update()
    {
       
    }
}