using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{
    public Slider backVolume;
    private AudioSource audio;

    private float backVol = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            audio = MenuBackGroundMusicScript.instance.audioSource;
            backVol = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
            backVolume.value = backVol;
            audio.volume = backVolume.value;
        }
        catch
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        try
        {
            backVol = backVolume.value;
            audio.volume = backVolume.value;
        }
        catch
        {

        }
        PlayerPrefs.SetFloat("BGMVolume", backVol);
    }
}
