﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 directionToMove;
    public float lifetime;
    private float lifetimeSeconds;
    public Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        lifetimeSeconds = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if (lifetimeSeconds <=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialVel)
    {
        myRigidBody.velocity = initialVel * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("boundary") && !other.gameObject.CompareTag("checkpoint") && !other.gameObject.CompareTag("enemyRoom") && !other.gameObject.CompareTag("boundary"))
        {
            SoundManager.PlaySound("arrowImpact");
            Destroy(this.gameObject);
        }
    }
}
