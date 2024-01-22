using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioClipRefScriptableObj : ScriptableObject
{
   [SerializeField] public AudioClip[] chop;
   [SerializeField] public AudioClip[] deliveryFail;
   [SerializeField] public AudioClip[] deliverySuccess;
   [SerializeField] public AudioClip[] footstep;
   [SerializeField] public AudioClip[] objectDrop;
   [SerializeField] public AudioClip[] objectPickup;
   [SerializeField] public AudioClip[] stoveSizzle;
   [SerializeField] public AudioClip[] trash;
   [SerializeField] public AudioClip[] warning;
   
}
