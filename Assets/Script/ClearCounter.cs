using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptObj kitchenObjectPrefab;
    [SerializeField] private Transform counterTopPoint;

    public void Interact()
    {
        Debug.Log("inteact!!!!");
        //int idx = Random.Range(0, tomatoPrefab.Length);
        Transform tomatoTransform = Instantiate(kitchenObjectPrefab.prefab, counterTopPoint);
        tomatoTransform.localPosition = Vector3.zero;

    }
}
