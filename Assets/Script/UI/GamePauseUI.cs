using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    public static GamePauseUI Instance { get; private set; }
    
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button optionBtn;

    private void Awake()
    {
        Instance = this;
        
        resumeBtn.onClick.AddListener((() =>
        {
            KitchenGameManager.Instance.TogglePauseGame();
        }));
        mainMenuBtn.onClick.AddListener((() =>
        {
            SceneManager.LoadScene(SceneLoader.Scene.MainMenuScene.ToString());
        }));
        
        optionBtn.onClick.AddListener((() =>
        {
            Hide();
           OptionsUI.Instance.Show();
        }));
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        Hide();
    }
    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e)
    {
      Show();
    }
    
    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        
        resumeBtn.Select();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
