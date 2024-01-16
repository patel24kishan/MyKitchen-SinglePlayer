using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
  public event EventHandler OnPlateSpawned;
  
  [SerializeField] private KitchenObjectScriptObj plateKitchenObjectScriptObj;
  private float spawmPlateTimer=0f;
  private float spawmPlateTimerMax = 4f;

  private int platesSpawnAmount=0;
  private int platesSpawnAmountMax = 4;

  
  private void Update()
  {
    spawmPlateTimer += Time.deltaTime;
    if (spawmPlateTimer > spawmPlateTimerMax)
    {
      spawmPlateTimer = 0f;

      if (platesSpawnAmount < platesSpawnAmountMax)
      {
        platesSpawnAmount++;
       OnPlateSpawned?.Invoke(this,EventArgs.Empty);
      }
    }
  }
}
