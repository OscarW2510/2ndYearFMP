﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, enemyDeathSound, walkingSound, arrowShotSound, potSmashSound, arrowImpactSound, coinSound, heartSound, chestOpenSound, campfireSound,
        magicBottleSound, swordWooshSound, enemyHitSound,indoorWalkingSound, caveWalkingSound;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        playerHitSound = Resources.Load<AudioClip>("playerHit");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");
        walkingSound = Resources.Load<AudioClip>("walk");
        arrowShotSound = Resources.Load<AudioClip>("arrowShot");
        arrowImpactSound = Resources.Load<AudioClip>("arrowImpact");
        potSmashSound = Resources.Load<AudioClip>("potSmash");
        coinSound = Resources.Load<AudioClip>("coinPickUp");
        heartSound = Resources.Load<AudioClip>("heartPickUp");
        chestOpenSound = Resources.Load<AudioClip>("chestOpening");
        campfireSound = Resources.Load<AudioClip>("campfire");
        magicBottleSound = Resources.Load<AudioClip>("magicBottle");
        swordWooshSound = Resources.Load<AudioClip>("swordWoosh");
        enemyHitSound = Resources.Load<AudioClip>("enemyHit");
        indoorWalkingSound = Resources.Load<AudioClip>("indoorWalking");
        caveWalkingSound = Resources.Load<AudioClip>("walkingInCave");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound, 0.22f);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound, 0.1f);
                break;
            case "walk":
                if (!audioSrc.isPlaying)
                {
                   audioSrc.PlayOneShot(walkingSound, 0.15f);
                }
                break;
            case "arrowImpact":
                audioSrc.PlayOneShot(arrowImpactSound, 0.1f);
                break;
            case "arrowShot":
                audioSrc.PlayOneShot(arrowShotSound, 0.1f);
                break;
            case "potSmash":
                audioSrc.PlayOneShot(potSmashSound, 0.25f);
                break;
            case "coinPickUp":
                audioSrc.PlayOneShot(coinSound, 0.2f);
                break;
            case "heartPickUp":
                audioSrc.PlayOneShot(heartSound, 0.15f);
                break;
            case "chestOpening":
                audioSrc.PlayOneShot(chestOpenSound, 0.15f);
                break;
            case "campfire":
                audioSrc.PlayOneShot(campfireSound, 0.25f);
                break;
            case "magicBottle":
                audioSrc.PlayOneShot(magicBottleSound, 0.15f);
                break;
            case "swordWoosh":
                audioSrc.PlayOneShot(swordWooshSound, 0.6f);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHitSound, 0.4f);
                break;
            case "walkingInCave":
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(caveWalkingSound, 0.5f);
                }
                break;
            case "indoorWalking":
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(indoorWalkingSound, 0.15f);
                }
                break;
        }
    }  
}
