using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeliveryManager : MonoBehaviour
{

   public event EventHandler OnRecipeSpawned;
   public event EventHandler OnRecipeCompleted;
   public event EventHandler OnRecipeSuccess;
   public event EventHandler OnRecipeFailed;
   public static DeliveryManager Instance { get; private set; }
   
   [SerializeField] private RecipeListScriptableObj recipeListScriptableObj;
   private List<RecipeScriptableObj> waitingRecipeList;
   private float spawnRecipeTimer;
   private float spawnRecipeTimerMax=4f;
   private float waitingRecipeListMax=4;
   private void Awake()
   {
      Instance = this;
      waitingRecipeList = new List<RecipeScriptableObj>();
   }

   private void Update()
   {
      spawnRecipeTimer -= Time.deltaTime;

      if (spawnRecipeTimer <= 0f)
      {
         spawnRecipeTimer = spawnRecipeTimerMax;

         if (waitingRecipeList.Count < waitingRecipeListMax)
         {
            RecipeScriptableObj waitingRecipeScriptableObj =
               recipeListScriptableObj.recipeScriptableObjList[
                  Random.Range(0, recipeListScriptableObj.recipeScriptableObjList.Count)];
            waitingRecipeList.Add(waitingRecipeScriptableObj);
            
            OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
         }
      }
   }

   
   /// <summary>
   /// The compelexity of plate-recipe matchs should be improved by unecessary nested-Loop
   /// </summary>
   /// <param name="plateKitchenObject"></param>
   public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
   {
      for (int i = 0; i < waitingRecipeList.Count; i++)
      {
         RecipeScriptableObj waitingRecipeScriptableObj = waitingRecipeList[i];

         if (waitingRecipeScriptableObj.kitchenObjectScriptObjList.Count==plateKitchenObject.GetKitchenObjectScriptObjList().Count)
         {
            //Same number of Ingredients
            bool plateContentMatchesRecipe = true;
            foreach (KitchenObjectScriptObj recipeKitchenObjectScriptObj in waitingRecipeScriptableObj.kitchenObjectScriptObjList)
            {
               bool ingredientFound = false;
               foreach (KitchenObjectScriptObj plateKitchenObjectScriptObj in plateKitchenObject.GetKitchenObjectScriptObjList())
               {
                  if (recipeKitchenObjectScriptObj==plateKitchenObjectScriptObj)
                  {
                     //Ingredient found
                     ingredientFound = true;
                     break;
                  }
               }
               if (!ingredientFound)
               {
                  //Recipe ingredients was not found on Plate
                  plateContentMatchesRecipe = false;
               }
            }

            if (plateContentMatchesRecipe)
            {
               //Ingredient of Plate matches recipe
               waitingRecipeList.RemoveAt(i);
               
               OnRecipeCompleted?.Invoke(this,EventArgs.Empty);
               OnRecipeSuccess?.Invoke(this,EventArgs.Empty);
               return;
            }
         }
      }
      
      //No match Found
      //Player did not deliver correct Recipe
      OnRecipeFailed?.Invoke(this,EventArgs.Empty);
   }

   public List<RecipeScriptableObj> GetWaitingRecipeList()
   {
      return waitingRecipeList;
   }
}
