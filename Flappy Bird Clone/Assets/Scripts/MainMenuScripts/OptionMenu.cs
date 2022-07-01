using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Slider volumeSlider;

    public void Start()
    {
        //Default Volume
        if (!PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }


    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }


    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("gameVolume", volumeSlider.value);
    }
}
