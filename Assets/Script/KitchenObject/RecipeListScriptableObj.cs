using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu()]
public class RecipeListScriptableObj : ScriptableObject
{
    [SerializeField] public List<RecipeScriptableObj> recipeScriptableObjList;
}
