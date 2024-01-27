using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    [SerializeField]
    private float loadingWaitTime = 3f;
    private void Update()
    {

        loadingWaitTime -= Time.deltaTime;
        if (loadingWaitTime<0)
        {
            //isFirstUpdate = false;
            
            SceneLoader.LoaderCallback();
        }
        
    }
}
