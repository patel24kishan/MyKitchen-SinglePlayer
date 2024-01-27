using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
   public event EventHandler OnGameStateChanged;
   public static KitchenGameManager Instance { get; private set; }
   private enum State{
      WaitingToStart,
      CountdownToStart,
      GamePlaying,
      GameOver,
   }

   
   private State state;
   private float waitingToStartTimer = 1f;
   private float countdownToStartTimer = 3f;
   private float gamePlayingTimer = 5f;

   private void Awake()
   {
      Instance = this;
      state = State.WaitingToStart;
   }

   private void Update()
   {
      switch (state)
      {
         case State.WaitingToStart:
            waitingToStartTimer -= Time.deltaTime;
            if (waitingToStartTimer<0f)
            {
               state = State.CountdownToStart;
               OnGameStateChanged?.Invoke(this,EventArgs.Empty);
            }
            break;
         case State.CountdownToStart:
            countdownToStartTimer -= Time.deltaTime;
            if (countdownToStartTimer<0f)
            {
               state = State.GamePlaying;
               OnGameStateChanged?.Invoke(this,EventArgs.Empty);
            }
            break;
         case State.GamePlaying:
            gamePlayingTimer -= Time.deltaTime;
            if (gamePlayingTimer<0f)
            {
               state = State.GameOver;
               OnGameStateChanged?.Invoke(this,EventArgs.Empty);
            }
            break;
         
         case State.GameOver:
            Debug.Log("Game Over!!!");
            break;
      }
      Debug.Log("State: "+state);
   }

   public bool IsGamePlaying()
   {
      return state == State.GamePlaying;
   }
   
   public bool IsStateeCountdownToStart()
   {
      return state == State.CountdownToStart;
   }

   public float getCountdownToStartTimer()
   {
      return countdownToStartTimer;
   }
}
