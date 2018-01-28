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
        slides.value = PlayerSettings.SoundLevel;
        volume = PlayerSettings.SoundLevel;
        //volume = 50.0f;
    }

    void OnGUI()
    {
        volume = slides.value;
        PlayerSettings.SoundLevel = volume;
    }
    void Update()
    {
       
    }
}