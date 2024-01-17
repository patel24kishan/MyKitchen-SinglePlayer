using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    public event EventHandler<OnIngredientsAddedEventArgs> OnIngredientsAdded;

    public class OnIngredientsAddedEventArgs : EventArgs
    {
        public KitchenObjectScriptObj kitchenObjectScriptObj;
    }
    [SerializeField] private List<KitchenObjectScriptObj> validKitchenObjectScriptObjList;
    private List<KitchenObjectScriptObj> kitchenObjectScriptObjList;

    private void Awake()
    {
        kitchenObjectScriptObjList = new List<KitchenObjectScriptObj>();
    }

    public bool TryAddIngredients(KitchenObjectScriptObj kitchenObjectScriptObj)
    {
        //Check for valid Item
        if (!validKitchenObjectScriptObjList.Contains(kitchenObjectScriptObj))
        {
            return false;
        }

        if (kitchenObjectScriptObjList.Contains(kitchenObjectScriptObj))
            {
                return false;
            }
            else
            {
                kitchenObjectScriptObjList.Add(kitchenObjectScriptObj);
                OnIngredientsAdded?.Invoke(this,new OnIngredientsAddedEventArgs
                {
                    kitchenObjectScriptObj = kitchenObjectScriptObj
                });
                return true;
            }
    }
}
