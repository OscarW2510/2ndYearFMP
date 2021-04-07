using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Enemy boss;

    public Slider healthBar;

    private bool active;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           active = true;
           healthBar.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
        healthBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (active)
        {
            healthBar.value = boss.health / boss.maxHealth.initialValue;
        }
    }
}
