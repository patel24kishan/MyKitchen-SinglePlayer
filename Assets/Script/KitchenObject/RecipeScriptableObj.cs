using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeScriptableObj : ScriptableObject
{
    [SerializeField] public List<KitchenObjectScriptObj> kitchenObjectScriptObjList;
    public string recipeName;
}
