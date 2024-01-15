using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class BurningRecipeScriptableObj : ScriptableObject
{
    public KitchenObjectScriptObj input;
    public KitchenObjectScriptObj output;
    public float burningTimerMax;
}
