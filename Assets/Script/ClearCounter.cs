using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectPrefab;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject!=null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
              //  Debug.Log(kitchenObject.GetClearCounter());
            }
        }
      
    }

    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchObjTransform = Instantiate(kitchenObjectPrefab.prefab, counterTopPoint);
            kitchObjTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        }
        else
        {
            //kitchenObject.SetClearCounter(player);
            Debug.Log(kitchenObject.GetKitchenObject());
        }
    }

    public Transform GetkitchenobjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
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
        return kitchenObject != null;
    }
}
