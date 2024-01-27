using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameCountDownText;
    
    private void Start()
    {
        KitchenGameManager.Instance.OnGameStateChanged += KitchenGameManager_OnGameStateChanged;
        
        Hide();
    }
    
    private void KitchenGameManager_OnGameStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsStateeCountdownToStart())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        gameCountDownText.text =Mathf.Ceil( KitchenGameManager.Instance.getCountdownToStartTimer()).ToString();
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
