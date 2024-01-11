using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectPrefab;
   
    public override void Interact(Player player)
    {
        /*if (kitchenObjectParent == null)
        {
            Transform kitchObjTransform = Instantiate(kitchenObjectPrefab.prefab, counterTopPoint);
            kitchObjTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObjectParent.SetKitchenObjectParent(player);
              }*/
    }
}
