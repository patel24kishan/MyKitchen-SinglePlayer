using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectPrefab;
    public override void Interact(Player player)
    {
            Transform kitchObjTransform = Instantiate(kitchenObjectPrefab.prefab);
            kitchObjTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
    }
    
}
