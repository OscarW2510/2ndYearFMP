using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : PowerUp
{
    public FloatValue playerHealth;
    public float amountToIncrease;
    public FloatValue heartContainers;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.RuntimeValue > playerHealth.initialValue)
            {
                playerHealth.RuntimeValue = playerHealth.initialValue;
            }
            //if(playerHealth.initialValue > heartContainers.RuntimeValue * 2f)
            //{
            //    playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            //}
            SoundManager.PlaySound("heartPickUp");
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
