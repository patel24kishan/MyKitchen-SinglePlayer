using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
   [Serializable]
   public struct  KitchenObjectScirptObj_gameObject
   {
   public KitchenObjectScriptObj kitchenObjectScriptObj;
   public GameObject gameObject;
   }
   [SerializeField]
   private PlateKitchenObject plateKitchenObject;

   [SerializeField] private List<KitchenObjectScirptObj_gameObject> kitchenObjectScirptObjGameObjectList;
   private void Start()
   {
      plateKitchenObject.OnIngredientsAdded += PlateKitchenObject_OnIngredientsAdded;
      foreach (KitchenObjectScirptObj_gameObject kitchenObject in kitchenObjectScirptObjGameObjectList)
      {
         kitchenObject.gameObject.SetActive(false);
      }
   }

   private void PlateKitchenObject_OnIngredientsAdded(object sender, PlateKitchenObject.OnIngredientsAddedEventArgs e)
   {
      foreach (KitchenObjectScirptObj_gameObject kitchenObject in kitchenObjectScirptObjGameObjectList)
      {
         if (kitchenObject.kitchenObjectScriptObj==e.kitchenObjectScriptObj)
         {
            kitchenObject.gameObject.SetActive(true);
            
         }
         
      }
      
   }
}
