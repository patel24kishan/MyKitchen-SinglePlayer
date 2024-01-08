using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
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
            Debug.Log("If I");
            if (kitchenObject!=null)
            {
                Debug.Log("else I");
                kitchenObject.SetClearCounter(secondClearCounter);
              //  Debug.Log(kitchenObject.GetClearCounter());
            }
        }
      
    }

    public void Interact()
    {
        if (kitchenObject == null)
        {
           // Debug.Log("If I");
            Transform kitchObjTransform = Instantiate(kitchenObjectPrefab.prefab, counterTopPoint);
            kitchObjTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        }
        else
        {
           // Debug.Log("else I");
            Debug.Log(kitchenObject.GetClearCounter());
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
