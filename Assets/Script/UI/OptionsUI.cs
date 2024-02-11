using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }
    [SerializeField] private Button soundBtn;
    [SerializeField] private Button musicBtn;
    [SerializeField] private Button closeBtn;
   
    [SerializeField] private Button moveUpBtn;
    [SerializeField] private Button moveDownBtn;
    [SerializeField] private Button moveLeftBtn;
    [SerializeField] private Button moveRightBtn;
    [SerializeField] private Button interactBtn;
    [SerializeField] private Button interactAltBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button gamepadInteractBtn;
    [SerializeField] private Button gamepadInteractAltBtn;
    [SerializeField] private Button gamepadPauseBtn;
    
    [SerializeField] private TextMeshProUGUI moveUpTxt;
    [SerializeField] private TextMeshProUGUI moveDownTxt;
    [SerializeField] private TextMeshProUGUI moveLeftTxt;
    [SerializeField] private TextMeshProUGUI moveRightTxt;
    [SerializeField] private TextMeshProUGUI interactTxt;
    [SerializeField] private TextMeshProUGUI interactAltTxt;
    [SerializeField] private TextMeshProUGUI pauseTxt;
    [SerializeField] private TextMeshProUGUI gamepadInteractTxt;
    [SerializeField] private TextMeshProUGUI gamepadInteractAltTxt;
    [SerializeField] private TextMeshProUGUI gamepadPauseTxt;

    [SerializeField] private TextMeshProUGUI soundText;
    [SerializeField] private TextMeshProUGUI musicText;
    
    [SerializeField] private Transform keyBindingInProgressScreen;
    

    private void Awake()
    {
      
        Instance = this;
        
        soundBtn.onClick.AddListener((() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateSoundVisual();
        }));
        
        
        musicBtn.onClick.AddListener((() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateMusicVisual();
        }));
        
        closeBtn.onClick.AddListener((() =>
        { 
            Hide();
            GamePauseUI.Instance.Show();
        }));
        
        moveUpBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Move_Up);
        });       
        
        moveDownBtn.onClick.AddListener(() =>
        {
           ReBindkey(GameInput.Binding.Move_Down);
        });
        
        moveLeftBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Move_Left);
        }); 
        
        moveRightBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Move_Right);
        });  
        
        interactBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Interact);
        }); 
        
        interactAltBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.InteractAlt);
        });
        
        pauseBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Pause);
        });
        
        gamepadInteractBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Gamepad_Interact);
        }); 
        
        gamepadInteractAltBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Gamepad_InteractAlt);
        });
        
        gamepadPauseBtn.onClick.AddListener(() =>
        {
            ReBindkey(GameInput.Binding.Gamepad_Pause);
        });
        
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        UpdateSoundVisual();
        UpdateMusicVisual();
        UpdateKeyBindingVisual();
        Hide();
        HideKeyBindingInProgressScreen();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }
    private void UpdateSoundVisual()
    {
        soundText.text = "SOUND: " + (Mathf.Round(SoundManager.Instance.GetGameVolume() * 10f)).ToString();
    }
    
    private void UpdateMusicVisual()
    {
        musicText.text = "MUSIC: " + (Mathf.Round(MusicManager.Instance.GetMusicVolume() * 10f)).ToString();
    }
    
    private void UpdateKeyBindingVisual()
    {
        moveUpTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Up).ToString();
        moveDownTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Down).ToString();
        moveLeftTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Left).ToString();
        moveRightTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Right).ToString();
        interactTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Interact).ToString();
        interactAltTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.InteractAlt).ToString();
        pauseTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Pause).ToString();
        gamepadInteractTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_Interact).ToString();
        gamepadInteractAltTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_InteractAlt).ToString();
        gamepadPauseTxt.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_Pause).ToString();
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        
        soundBtn.Select();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void ShowKeyBindingInProgressScreen()
    {
        keyBindingInProgressScreen.gameObject.SetActive(true);
    }

    public void HideKeyBindingInProgressScreen()
    {
        keyBindingInProgressScreen.gameObject.SetActive(false);
    }

    private void ReBindkey(GameInput.Binding binding)
    {
        ShowKeyBindingInProgressScreen();
        GameInput.Instance.ReMappingKeyBinding(binding,()=>
        {
            UpdateKeyBindingVisual();
            HideKeyBindingInProgressScreen();
        });
    }
}
