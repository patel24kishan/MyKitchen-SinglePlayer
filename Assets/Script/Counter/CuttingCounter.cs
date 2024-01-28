using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IHasProgress
{
    public static event EventHandler onAnyCut;
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler OnCutObject;
    [SerializeField] private CuttingRecipeScriptableObj[] cuttingRecipeScriptableObjArray;

    private int cuttingProgress=0;

    new public static void ResetStaticData()
    {
        onAnyCut = null;
    }
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
                    CuttingRecipeScriptableObj cuttingRecipeScriptableObj =
                        GetCuttingRecipeScriptableObjWithInput(GetKitchenObject().GetKitchenObjectScriptObj());
                    OnProgressChanged?.Invoke(this,new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress/cuttingRecipeScriptableObj.cuttingProgressMax
                    });
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
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {//Player has plate
                    
                    plateKitchenObject=player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredients(GetKitchenObject().GetKitchenObjectScriptObj()))
                    {
                        GetKitchenObject().DestroyKitchenObject();
                    }
                }
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
            // Cut object only if it has object AND it can be cut
            
            cuttingProgress++;
            
            OnCutObject?.Invoke(this,EventArgs.Empty);
            onAnyCut?.Invoke(this,EventArgs.Empty);
            
            CuttingRecipeScriptableObj cuttingRecipeScriptableObj =
                GetCuttingRecipeScriptableObjWithInput(GetKitchenObject().GetKitchenObjectScriptObj());
            
            //Edit progress bar
            OnProgressChanged?.Invoke(this,new IHasProgress.OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress/cuttingRecipeScriptableObj.cuttingProgressMax
            });
            
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
