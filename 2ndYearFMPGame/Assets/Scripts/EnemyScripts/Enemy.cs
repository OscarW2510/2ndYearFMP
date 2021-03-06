﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle, walk, attack, stagger
}


public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;
    private float deathEffectDelay = 1f;
    public LootTable thisLoot;
    private bool hasDroppedLoot = false;
    //public bool drop;
    //public GameObject theDrop;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }
    protected virtual void TakeDamage(float damage)
    {
        SoundManager.PlaySound("enemyHit");
        health -= damage;
        if (health <= 0)
        {
            DeathEffect();
            MakeLoot();
            if (OnDeath != null)
            {
                OnDeath.Invoke();
                OnDeath = null;
            }
            this.gameObject.SetActive(false);
            SoundManager.PlaySound("enemyDeath");
            Invoke("Respawn", 120f);
            //if (drop) Instantiate(theDrop, transform.position, transform.rotation);
        }
    }

    protected void Respawn()
    {
        this.gameObject.SetActive(true);
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    protected void MakeLoot()
    {
        if(thisLoot != null && hasDroppedLoot == false)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
        hasDroppedLoot = true;
    }

    protected void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }
    public void Knock(Rigidbody2D myRigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidBody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;

        }
    }

    public delegate void DeathCount();

    public event DeathCount OnDeath;
}
