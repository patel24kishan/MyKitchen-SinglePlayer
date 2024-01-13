using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeScriptableObj[] cuttingRecipeScriptableObjArray;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasObjectWithInput(player.GetKitchenObject().GetKitchenObjectScriptObj()))
                {
                    // Drop Item if it can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
                //Player is carrying Object
            }
            else
            {
                // Assign to Player 
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasObjectWithInput(GetKitchenObject().GetKitchenObjectScriptObj()))
        {
            // Cut it only if it has object AND it can be cut
            KitchenObjectScriptObj kitchenObjectSliced = GetOutputForInput(GetKitchenObject().GetKitchenObjectScriptObj());
            GetKitchenObject().DestroyKitchenObject();
            KitchenObject.SpawnKitchenObject(kitchenObjectSliced, this);
        }
    }
    
    public bool HasObjectWithInput(KitchenObjectScriptObj kitchenObjectScriptObj)
    {
        foreach (CuttingRecipeScriptableObj cuttingRecipekitchenObj in cuttingRecipeScriptableObjArray)
        {
            if (cuttingRecipekitchenObj.input==kitchenObjectScriptObj)
            {
                return true;
            }
        }
        return false;
    }
    public KitchenObjectScriptObj GetOutputForInput(KitchenObjectScriptObj kitchenObjectScriptObj)
    {
        foreach (CuttingRecipeScriptableObj cuttingRecipekitchenObj in cuttingRecipeScriptableObjArray)
        {
            if (cuttingRecipekitchenObj.input==kitchenObjectScriptObj)
            {
                return cuttingRecipekitchenObj.output;
            }
        }
        return null;
    }
}
