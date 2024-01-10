using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectSO;

    //private ClearCounter kitchenObjectParent;

    private IKitchenObjectParent kitchenObjectParent;
    public  KitchenObjectScriptObj GetKitchenObjectScriptObj()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent!=null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent=kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IkitchenObjectParent already has Object");
        }
        kitchenObjectParent.SetKitchenObject(this);
        
        transform.parent = kitchenObjectParent.GetkitchenobjectFollowTransform();
        transform.localPosition=Vector3.zero;
        ;
    }
    
    public IKitchenObjectParent GetKitchenObject()
    {
        return kitchenObjectParent;
    }
}
