using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float footstepTimer;
    private float footstepTimerMax = 0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f) ;
        {
            footstepTimer = footstepTimerMax;

            //Need Adjustment as Sound feels scrambled
            if (player.IsWalking())
            {
                SoundManager.Instance.PlayFootStepSound(player.transform.position);
            }
        }
    }
}
