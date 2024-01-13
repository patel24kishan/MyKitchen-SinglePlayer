using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectScriptObj TomatoSlicedSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
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
                //Do nothing
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            // Cut it
            GetKitchenObject().DestroyKitchenObject();

            KitchenObject.SpawnKitchenObject(TomatoSlicedSO, this);
        }

    }
}
