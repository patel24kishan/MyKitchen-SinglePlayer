using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP = "POP_UP";

    private Animator animator;
    [SerializeField] private DeliveryCounter deliveryCounter;
    
    [SerializeField] private Image deliveryBackground;
    [SerializeField] private Image deliveryImage;
    
    [SerializeField] private TextMeshProUGUI deliveryTxt;
    
    [SerializeField] private Color deliverySuccessColor;
    [SerializeField] private Color deliveryFailedColor;
   
    [SerializeField] private Sprite deliverySuccessSprite;
    [SerializeField] private Sprite deliveryFailedSprite;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        
        Hide();
    }
    
    private void DeliveryManager_OnRecipeSuccess(object sender, EventArgs e)
    {
        Show();
        animator.SetTrigger(POPUP);
        deliveryBackground.color = deliverySuccessColor;
        deliveryImage.sprite = deliverySuccessSprite;
        deliveryTxt.text = "DELIVERY\nSUCCESS";
    }
    
    private void DeliveryManager_OnRecipeFailed(object sender, EventArgs e)
    {
        Show();
        animator.SetTrigger(POPUP);
        deliveryBackground.color = deliveryFailedColor;
        deliveryImage.sprite = deliveryFailedSprite;
        deliveryTxt.text = "DELIVERY\nFAILED";
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
