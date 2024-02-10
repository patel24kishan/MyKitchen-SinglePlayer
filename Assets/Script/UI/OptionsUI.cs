using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }
    [SerializeField] private Button soundBtn;
    [SerializeField] private Button musicBtn;
    [SerializeField] private Button closeBtn;
    [SerializeField] private TextMeshProUGUI soundText;
    [SerializeField] private TextMeshProUGUI musicText;

    private void Awake()
    {
      
        Instance = this;
        
        soundBtn.onClick.AddListener((() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateSoundVisual();
        }));
        
        
        musicBtn.onClick.AddListener((() =>
        {
            MusicManager.Instance.ChangeVolume();
           
            UpdateMusicVisual();
        }));
        
        closeBtn.onClick.AddListener((() =>
        { 
            Hide();
            GamePauseUI.Instance.Show();
        }));
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        UpdateSoundVisual();
        UpdateMusicVisual();
        Hide();
    }
    
    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }
    private void UpdateSoundVisual()
    {
        soundText.text = "SOUND: " + (Mathf.Round(SoundManager.Instance.GetGameVolume() * 10f)).ToString();
    }
    
    private void UpdateMusicVisual()
    {
        musicText.text = "MUSIC: " + (Mathf.Round(MusicManager.Instance.GetMusicVolume() * 10f)).ToString();
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
