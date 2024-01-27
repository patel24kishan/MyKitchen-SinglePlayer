using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameClockUI : MonoBehaviour
{
    [SerializeField] private Image gameclockImage;

    private void Update()
    {
        gameclockImage.fillAmount = KitchenGameManager.Instance.getGamePlayingTimerNormalized();
    }
}
