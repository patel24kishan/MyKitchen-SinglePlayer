using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class FryingRecipeScriptableObj : ScriptableObject
{
    public KitchenObjectScriptObj input;
    public KitchenObjectScriptObj output;
    public float fryingTimerMax;
}
