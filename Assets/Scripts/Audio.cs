using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider slider;
    private void Start()
    {
        audioMixer.SetFloat("volume", GetFloat("VolumePref"));
        slider.value = GetFloat("VolumePref");
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume",volume);
        PlayerPrefs.SetFloat("VolumePref", volume);
    }
    public float GetFloat(string KeyName)
    {
        return PlayerPrefs.GetFloat(KeyName);
    }
}
