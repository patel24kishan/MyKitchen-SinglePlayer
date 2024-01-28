using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
   public event EventHandler OnGameStateChanged;
   public event EventHandler OnGamePaused;
   public event EventHandler OnGameUnpaused;
   public static KitchenGameManager Instance { get; private set; }
   private enum State{
      WaitingToStart,
      CountdownToStart,
      GamePlaying,
      GameOver,
   }

   
   private State state;
  [SerializeField] private float waitingToStartTimer = 1f;
  [SerializeField] private float countdownToStartTimer = 3f;
  [SerializeField] private float gamePlayingTimerMax = 5f;
  private bool isGamePaused;
  private float gamePlayingTimer;

   private void Awake()
   {
      Instance = this;
      state = State.WaitingToStart;
      
   }

   private void Start()
   {
      GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
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
               gamePlayingTimer = gamePlayingTimerMax;
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
            break;
      }
      Debug.Log("State: "+state);
   }
   
   private void GameInput_OnPauseAction(object sender, System.EventArgs e)
   {
      TogglePauseGame();
   }

   public void TogglePauseGame()
   {
      isGamePaused = !isGamePaused;
      if (isGamePaused)
      {
        Time.timeScale = 0f; 
        OnGamePaused?.Invoke(this,EventArgs.Empty);
      }
      else
      {
         Time.timeScale = 1f;
         OnGameUnpaused?.Invoke(this,EventArgs.Empty);
      }
   }

   
   public bool IsGamePlaying()
   {
      return state == State.GamePlaying;
   }
   
   public bool IsStateCountdownToStart()
   {
      return state == State.CountdownToStart;
   }
   
   public bool IsGameOver()
   {
      return state == State.GameOver;
   }

   public float getCountdownToStartTimer()
   {
      return countdownToStartTimer;
   }

   public float getGamePlayingTimerNormalized()
   {
      
      return (gamePlayingTimer / gamePlayingTimerMax);
   }
}
