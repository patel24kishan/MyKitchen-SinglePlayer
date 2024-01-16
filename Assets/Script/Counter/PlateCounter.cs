using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
  public event EventHandler OnPlateSpawned;
  public event EventHandler OnPlateRemoved;
  
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
  
  public override void Interact(Player player)
  {
   
      if (!player.HasKitchenObject())
      {
        //Player has no Object
        if (platesSpawnAmount>0)
        {
          platesSpawnAmount--;
          
          KitchenObject.SpawnKitchenObject(plateKitchenObjectScriptObj, player);
          OnPlateRemoved?.Invoke(this,EventArgs.Empty);
        }
      }
      else
      {
        //Do Nothing
      }
  }
}
