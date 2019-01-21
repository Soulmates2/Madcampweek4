using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackGroundMusicScript : MonoBehaviour
{
    public static MenuBackGroundMusicScript instance = null;
    public AudioSource audioSource;
    public AudioClip[] bgm;
    public int track_number = 0;

    public AudioClip[] Gamebgm;
    public int Gamebgm_track_number = 0;

    public bool menu = true;

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
        {
            if (menu)
            {
                RandomPlay();
            }
            else
            {
                GameBackGroundMusic();
            }
        }
    }

    public void RandomPlay()
    {
        audioSource.Stop();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm[track_number];
        track_number += 1;
        track_number = track_number % bgm.Length;
        audioSource.volume = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
        audioSource.mute = false;
        audioSource.Play();
    }

    public void GameBackGroundMusic()
    {
        audioSource.Stop();
        audioSource = GetComponent<AudioSource>();
        Gamebgm_track_number = Random.Range(0, Gamebgm.Length);
        audioSource.clip = Gamebgm[Gamebgm_track_number];
        Gamebgm_track_number += 1;
        Gamebgm_track_number = Gamebgm_track_number % bgm.Length;
        audioSource.volume = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
        audioSource.mute = false;
        audioSource.Play();
    }

}
