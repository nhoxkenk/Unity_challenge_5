using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSlider : MonoBehaviour
{
    AudioSource audioSource;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        slider.onValueChanged.AddListener(setVolume);
    }

    void setVolume(float volume)
    {
        audioSource.volume = volume;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
