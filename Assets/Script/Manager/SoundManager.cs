using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefScriptableObj audioClipRef;
    public static SoundManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess +=DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed +=DeliveryManager_OnRecipeFailed;
        CuttingCounter.onAnyCut +=CuttingCounter_OnAnyCut;
        Player.Instance.onKitchenObjectPickup += Player_OnKitchenObjectPickup;
        BaseCounter.onKitchenObjectDrop += BaseCounter_OnKitchenObjectDrop;
        TrashCounter.onKitchenObjectTrashed += TrashCounter_OnKitchenObjectTrashed;
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRef.deliverySuccess,deliveryCounter.transform.position);
    }
    
    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRef.deliveryFail,deliveryCounter.transform.position);
    }
    
    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipRef.chop,cuttingCounter.transform.position);
    }
    
    private void Player_OnKitchenObjectPickup(object sender, System.EventArgs e)
    {
        Player player = Player.Instance;
        PlaySound(audioClipRef.objectPickup,player.transform.position);
    }
    
    private void BaseCounter_OnKitchenObjectDrop(object sender, System.EventArgs e)
    {
        BaseCounter counter = sender as BaseCounter;
        PlaySound(audioClipRef.objectDrop,counter.transform.position);
    }
    
    private void TrashCounter_OnKitchenObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter counter = sender as TrashCounter;
        PlaySound(audioClipRef.trash,counter.transform.position);
    }
    
    public void PlaySound(AudioClip[] audioClipArray, Vector3 position,float volume=1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0,audioClipArray.Length)],position,volume);
    }
    
    public void PlayFootStepSound(Vector3 position,float volume=1f)
    {
        PlaySound(audioClipRef.footstep,position,volume);
    }
    
    public void PlaySound(AudioClip audioClip, Vector3 position,float volume=1f)
    {
        AudioSource.PlayClipAtPoint(audioClip,position,volume);
    }
}
