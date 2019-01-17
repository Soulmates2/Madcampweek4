using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackGroundMusicScript : MonoBehaviour
{
    public static MenuBackGroundMusicScript instance = null;
    public AudioSource audioSource;
    public AudioClip[] bgm;
    public int track_number = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (!audioSource.isPlaying)
            RandomPlay();
    }

    void RandomPlay()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm[track_number];
        track_number += 1;
        track_number = track_number % bgm.Length;
        audioSource.volume = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
        audioSource.mute = false;
        audioSource.Play();
    }

}
