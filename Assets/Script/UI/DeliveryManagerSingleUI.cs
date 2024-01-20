using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;

    private void Start()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    public void setRecipeScriptabelObj(RecipeScriptableObj recipeScriptableObj)
    {
        recipeNameText.text = recipeScriptableObj.recipeName;
        
        foreach (Transform child in iconContainer)
        {
            if (child==iconTemplate) continue;
            Destroy(child.gameObject);
            
        }
        foreach (KitchenObjectScriptObj kitchenScriptObj in recipeScriptableObj.kitchenObjectScriptObjList)
        {
            Transform iconTransform=Instantiate(iconTemplate, iconContainer);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = kitchenScriptObj.sprite;
        }
    }
}
