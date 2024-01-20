using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;
    private void Start()
    {
        iconTemplate.gameObject.SetActive(false);
        plateKitchenObject.OnIngredientsAdded += PlateKitchenObject_OnIngredientsAdded;
        
    }

    private void PlateKitchenObject_OnIngredientsAdded(object sender, PlateKitchenObject.OnIngredientsAddedEventArgs e)
    {
        UpdatePlateVisual();
    }

    private void  UpdatePlateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child==iconTemplate) continue;
            Destroy(child.gameObject);
            
        }
        foreach (KitchenObjectScriptObj kitchenObject in plateKitchenObject.GetKitchenObjectScriptObjList())
        {
            Transform iconTransform=Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectScriptObjImage(kitchenObject);
        }
    }
}
