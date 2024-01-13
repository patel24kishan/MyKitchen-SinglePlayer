using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeScriptableObj[] cuttingRecipeScriptableObjArray;

    private int cuttingProgress=0;
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
                    cuttingProgress = 0;
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
            
            cuttingProgress++;
            
            CuttingRecipeScriptableObj cuttingRecipeScriptableObj =
                GetCuttingRecipeScriptableObjWithInput(GetKitchenObject().GetKitchenObjectScriptObj());

            if (cuttingProgress >= cuttingRecipeScriptableObj.cuttingProgressMax)
            {
                KitchenObjectScriptObj kitchenObjectSliced =
                    GetOutputForInput(GetKitchenObject().GetKitchenObjectScriptObj());
                
                GetKitchenObject().DestroyKitchenObject();
                
                KitchenObject.SpawnKitchenObject(kitchenObjectSliced, this);
            }
        }
    }
    
    public bool HasObjectWithInput(KitchenObjectScriptObj inputKitchenObjectScriptObj)
    {
        CuttingRecipeScriptableObj cuttingRecipeScriptableObj =
            GetCuttingRecipeScriptableObjWithInput(inputKitchenObjectScriptObj);

        return cuttingRecipeScriptableObj!=null;
    }
    public KitchenObjectScriptObj GetOutputForInput(KitchenObjectScriptObj inputKitchenObjectScriptObj)
    {
        CuttingRecipeScriptableObj cuttingRecipeScriptableObj =
            GetCuttingRecipeScriptableObjWithInput(inputKitchenObjectScriptObj);
        
            if (cuttingRecipeScriptableObj!=null)
            {
                return cuttingRecipeScriptableObj.output;
            }
            else
            {
                return null;
            }
    }
    
    public CuttingRecipeScriptableObj GetCuttingRecipeScriptableObjWithInput(KitchenObjectScriptObj inputKitchenObjectScriptObj)
    {
        foreach (CuttingRecipeScriptableObj cuttingRecipekitchenObj in cuttingRecipeScriptableObjArray)
        {
            if (cuttingRecipekitchenObj.input==inputKitchenObjectScriptObj)
            {
                return cuttingRecipekitchenObj;
            }
        }
        return null;
    }
    
}
