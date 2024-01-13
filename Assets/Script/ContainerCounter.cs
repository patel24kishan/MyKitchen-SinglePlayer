using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private KitchenObjectScriptObj kitchenObjectPrefab;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            Transform kitchObjTransform = Instantiate(kitchenObjectPrefab.prefab);
            kitchObjTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            
            OnPlayerGrabbedObject?.Invoke(this,EventArgs.Empty);
        }
    }
}
