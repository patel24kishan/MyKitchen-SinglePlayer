using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
   [SerializeField] private Transform counterTopPoint;

   public static event EventHandler onKitchenObjectDrop;
    private KitchenObject kitchenObject;
    
    public static void ResetStaticData()
    {
        onKitchenObjectDrop = null;
    }
    public virtual void Interact(Player player)
    {
        Debug.Log("BaseCounter.Interact()");
    }
    
    public virtual void InteractAlternate(Player player)
    {
      //  Debug.Log("BaseCounter.InteractAlternate()");
    }
    
    public Transform GetkitchenobjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        if (kitchenObject!=null)
        {
            onKitchenObjectDrop?.Invoke(this,EventArgs.Empty);
        } 
        this.kitchenObject = kitchenObject;
    }


    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }


    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject  != null;
    }
}
