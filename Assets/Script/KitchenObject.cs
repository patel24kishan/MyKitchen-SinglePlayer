using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectSO;

    private ClearCounter clearCounter;
    public  KitchenObjectScriptObj GetKitchenObjectScriptObj()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter!=null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter=clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has Object");
        }
        clearCounter.SetKitchenObject(this);
        
        transform.parent = clearCounter.GetkitchenobjectFollowTransform();
        transform.localPosition=Vector3.zero;
        ;
    }
    
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
