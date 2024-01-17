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

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
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
        
    }
    
    public IKitchenObjectParent GetKitchenObject()
    {
        return kitchenObjectParent;
    }

    public void DestroyKitchenObject()
    {
        Debug.Log("Destroy KitchenObject: "+this.name);
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject=this as PlateKitchenObject;
            ;
            return true;
        }
        else
        {
            plateKitchenObject = null;
            return false;
        }
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectScriptObj kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchObjTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchObjTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
        
        return kitchenObject;
    }
}
