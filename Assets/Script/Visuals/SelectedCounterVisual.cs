using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter clearCounter;
    [SerializeField] private GameObject[] selectedCounterVisual;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }
    
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter==clearCounter)
        {
           
            ShowSelectedCounter();
        }
        else
        {
           
            HideSelectedCounter();
        }
       
    }

    private void ShowSelectedCounter()
    {
        foreach (GameObject kitchenCounterObj in selectedCounterVisual )
        {
            kitchenCounterObj.SetActive(true);
        }
        
    }

    private void HideSelectedCounter()
    {
        foreach (GameObject kitchenCounterObj in selectedCounterVisual )
        {
            kitchenCounterObj.SetActive(false);
        }
    }
}
