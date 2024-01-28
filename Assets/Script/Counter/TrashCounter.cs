using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler onKitchenObjectTrashed;

    new public static void ResetStaticData()
    {
        onKitchenObjectTrashed = null;
    }
    public override void Interact(Player player)
    {
            if (player.HasKitchenObject())
            {
                onKitchenObjectTrashed?.Invoke(this,EventArgs.Empty);
                player.GetKitchenObject().DestroyKitchenObject();
            }
            else
            {
               //Do Nothing
            }
    }
}
