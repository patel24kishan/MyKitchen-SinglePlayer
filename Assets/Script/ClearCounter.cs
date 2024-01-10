using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectPrefab;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObjectParent;
    public void Interact(Player player)
    {
        if (kitchenObjectParent == null)
        {
            Transform kitchObjTransform = Instantiate(kitchenObjectPrefab.prefab, counterTopPoint);
            kitchObjTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObjectParent.SetKitchenObjectParent(player);
            Debug.Log(kitchenObjectParent.GetKitchenObject());
        }
    }

    public Transform GetkitchenobjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObjectParent)
    {
        this.kitchenObjectParent = kitchenObjectParent;
    }


    public KitchenObject GetKitchenObject()
    {
        return kitchenObjectParent;
    }


    public void ClearKitchenObject()
    {
        kitchenObjectParent = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObjectParent != null;
    }
}
