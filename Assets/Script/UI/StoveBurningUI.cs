using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurningUI : MonoBehaviour
{
   [SerializeField] private StoveCounter stoveCounter;

   private void Start()
   {
       stoveCounter.OnProgressChanged += StoveCounter_OnPrgressChanged;
       
       Hide();
   }
   
   private void StoveCounter_OnPrgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
   {
       float burnShowProgressAmount = .5f;
       bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

       if (show)
       {
           Show();
       }
       else
       {
           Hide();
       }
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
