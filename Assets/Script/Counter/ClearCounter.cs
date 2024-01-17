using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    
    [SerializeField] private KitchenObjectScriptObj kitchenObjectPrefab;
   
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                //Player has Kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
               //Player has nothing 
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {//Player has plate
                    
                    plateKitchenObject=player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredients(GetKitchenObject().GetKitchenObjectScriptObj()))
                    {
                        GetKitchenObject().DestroyKitchenObject();
                    }
                }
                else
                {
                    //player has no palte but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngredients(player.GetKitchenObject().GetKitchenObjectScriptObj()))
                        {
                            player.GetKitchenObject().DestroyKitchenObject();
                        }
                    }
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
