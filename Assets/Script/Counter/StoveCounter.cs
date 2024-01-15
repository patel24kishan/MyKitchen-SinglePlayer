using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class StoveCounter : BaseCounter
{

    private enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }
    
    [SerializeField] private FryingRecipeScriptableObj[] fryingRecipeScriptableObjsArray;
    [SerializeField] private BurningRecipeScriptableObj[] burningRecipeScriptableObjsArray;
    private FryingRecipeScriptableObj fryingRecipeScriptableObj;
    private BurningRecipeScriptableObj burningRecipeScriptableObj;
    private float fryingTimer;
    private float burningTimer;
    private State state;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                
                case State.Frying:
                    
                    fryingTimer += Time.deltaTime;
                    if (fryingTimer > fryingRecipeScriptableObj.fryingTimerMax)
                    {
                        //Fried
                        fryingTimer = 0f;
                        GetKitchenObject().DestroyKitchenObject();
                        KitchenObject.SpawnKitchenObject(fryingRecipeScriptableObj.output, this);
                        
                        state = State.Fried;
                        burningTimer = 0f;
                        burningRecipeScriptableObj =
                            GetBurningRecipeScriptableObjWithInput(GetKitchenObject().GetKitchenObjectScriptObj());
                    }
                    break;
                
                case State.Fried:
                    burningTimer += Time.deltaTime;
                    if (burningTimer > burningRecipeScriptableObj.burningTimerMax)
                    {
                        //Burned
                        burningTimer = 0f;
                        GetKitchenObject().DestroyKitchenObject();
                        KitchenObject.SpawnKitchenObject(burningRecipeScriptableObj.output, this);
                        
                        state = State.Burned;
                    }
                    break;
                
                case State.Burned:
                    break;
            }
            
        }
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasObjectWithInput(player.GetKitchenObject().GetKitchenObjectScriptObj()))
                {
                    // Drop Item if it can be Fried
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    fryingRecipeScriptableObj =
                        GetFryingRecipeScriptableObjWithInput(GetKitchenObject().GetKitchenObjectScriptObj());

                    state = State.Frying;
                    fryingTimer = 0f;
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

                state = State.Idle;
            }
        }
    }
    
    public bool HasObjectWithInput(KitchenObjectScriptObj inputKitchenObjectScriptObj)
    {
        FryingRecipeScriptableObj fryingRecipeObj =
            GetFryingRecipeScriptableObjWithInput(inputKitchenObjectScriptObj);

        return fryingRecipeObj!=null;
    }
    public KitchenObjectScriptObj GetOutputForInput(KitchenObjectScriptObj inputKitchenObjectScriptObj)
    {
        FryingRecipeScriptableObj fryingRecipeObj =
            GetFryingRecipeScriptableObjWithInput(inputKitchenObjectScriptObj);
        
        if (fryingRecipeObj!=null)
        {
            return fryingRecipeObj.output;
        }
        else
        {
            return null;
        }
    }
    
    public FryingRecipeScriptableObj GetFryingRecipeScriptableObjWithInput(KitchenObjectScriptObj inputKitchenObjectScriptObj)
    {
        foreach (FryingRecipeScriptableObj fryingRecipeObj in fryingRecipeScriptableObjsArray)
        {
            if (fryingRecipeObj.input==inputKitchenObjectScriptObj)
            {
                return fryingRecipeObj;
            }
        }
        return null;
    }
    
    public BurningRecipeScriptableObj GetBurningRecipeScriptableObjWithInput(KitchenObjectScriptObj inputKitchenObjectScriptObj)
    {
        foreach (BurningRecipeScriptableObj burningRecipeobj in burningRecipeScriptableObjsArray)
        {
            if (burningRecipeobj.input==inputKitchenObjectScriptObj)
            {
                return burningRecipeobj;
            }
        }
        return null;
    }
}
