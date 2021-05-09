using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveBossAreaLog : AreaLog
{
    protected override void TakeDamage(float damage)
    {
        SoundManager.PlaySound("enemyHit");
        health -= damage;
        if (health <= 0)
        {
            DeathEffect();
            MakeLoot();
            this.gameObject.SetActive(false);
            SoundManager.PlaySound("enemyDeath");
            Invoke("EndLevel", 5);
            //if (drop) Instantiate(theDrop, transform.position, transform.rotation);
        }
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(5);
    }
}
