﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBottle : PowerUp
{
    public Inventory playerInventory;
    public float magicValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(playerInventory.currentMagic < playerInventory.maxMagic)
            {
                playerInventory.currentMagic += magicValue;
                SoundManager.PlaySound("magicBottle");
                powerupSignal.Raise();
                if(playerInventory.currentMagic > playerInventory.maxMagic)
                {
                    playerInventory.currentMagic = playerInventory.maxMagic;
                }
                Destroy(this.gameObject);
            }
        } 
    }
}
