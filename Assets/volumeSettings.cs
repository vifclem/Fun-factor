using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour
{

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider soundSlider;
    const string mixer_sound = "SoundVolume";
    private void Awake()
    {
        soundSlider.onValueChanged.AddListener(SetSoundVolume);
    }
    void SetSoundVolume(float value)
    {
        audioMixer.SetFloat(mixer_sound, Mathf.Log10(value) * 20);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
