using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectSO;

    private KitchenObjectScriptObj getKitchenObjectScriptObj()
    {
        return kitchenObjectSO;
    }
}
