﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    public float textDisplayLength;
    public Vector2Value cameraStorage;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            if (cameraStorage != null)
            {
                cameraStorage.minValue = cam.minPosition;
                cameraStorage.maxValue = cam.maxPosition;
            }
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCO());
            }
        }
    }

    private IEnumerator placeNameCO()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(textDisplayLength);
        text.SetActive(false);
    }

}
