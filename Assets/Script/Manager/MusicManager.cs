using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    
    private const string PLAYER_PREFS_MUSIC_VOLUME = "musicVolume";
    
    private AudioSource audioSource;

    private float musicVolume = .3f;
    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        
        musicVolume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME,.3f);
        audioSource.volume = musicVolume;
    }
    
    public void ChangeVolume()
    {
        musicVolume += 0.1f;
        if (musicVolume>1f)
        {
            musicVolume = 0f;
        }

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME,musicVolume);
        PlayerPrefs.Save();
        audioSource.volume = musicVolume;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }
}
