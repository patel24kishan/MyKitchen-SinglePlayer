using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject selectedCounterVisual;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }
    
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter==clearCounter)
        {
            Debug.LogError("inside if");
            ShowSelectedCounter();
        }
        else
        {
            Debug.LogError("inside else");
            HideSelectedCounter();
        }
       
    }

    private void ShowSelectedCounter()
    {
        Debug.LogError("outside if");
        selectedCounterVisual.SetActive(true);
    }

    private void HideSelectedCounter()
    {
        Debug.LogError("outside else");
        selectedCounterVisual.SetActive(false);
    }
}
