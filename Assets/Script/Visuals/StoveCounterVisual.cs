using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField]
    private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObj;
    [SerializeField] private GameObject sizzlingParticleGameObj;

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStageChanged;
    }

    private void StoveCounter_OnStageChanged(object sender, StoveCounter.OnStateChangedArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        stoveOnGameObj.SetActive(showVisual);
        sizzlingParticleGameObj.SetActive(showVisual);
    }


}
