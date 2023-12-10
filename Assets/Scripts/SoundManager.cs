using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Slider Volume_slider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
            Load();
        }
        else
        {
            Load();
        }   
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = Volume_slider.value; 
        Save();
    }

    void Load()
    {
        Volume_slider.value = PlayerPrefs.GetFloat("musicvolume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("musicvolume",Volume_slider.value);
    }
}
