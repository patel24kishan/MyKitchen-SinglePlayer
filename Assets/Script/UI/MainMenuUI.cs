using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;

    private void Awake()
    {
        playBtn.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.GameScene);

        });
        
        quitBtn.onClick.AddListener(() =>
        {
                Application.Quit();
        });

        //Reset scene
        Time.timeScale = 1f;

    }
}
