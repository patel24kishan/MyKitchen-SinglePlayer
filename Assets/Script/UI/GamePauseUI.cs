using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button mainMenuBtn;

    private void Awake()
    {
        resumeBtn.onClick.AddListener((() =>
        {
            KitchenGameManager.Instance.TogglePauseGame();
        }));
        mainMenuBtn.onClick.AddListener((() =>
        {
            SceneManager.LoadScene(SceneLoader.Scene.MainMenuScene.ToString());
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
    
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}