using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator animator;

    private const string CUT = "Cut";

    private void Awake()
    {
        animator=GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCutObject += CuttingCounter_OnCutObject;
    }

    private void CuttingCounter_OnCutObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}
