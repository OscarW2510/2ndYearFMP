﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controls;
    // Start is called before the first frame update
    void Start()
    {
        controls.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            controls.SetActive(true);
            StartCoroutine("WaitForSec");
            Time.timeScale = 0;
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSecondsRealtime(7);
        Destroy(controls);
        Destroy(gameObject);
        Time.timeScale = 1;
    }
}
