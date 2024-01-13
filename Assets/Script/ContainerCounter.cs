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
            KitchenObject.SpawnKitchenObject(kitchenObjectPrefab, player);
            
            OnPlayerGrabbedObject?.Invoke(this,EventArgs.Empty);
        }
    }
    
}
