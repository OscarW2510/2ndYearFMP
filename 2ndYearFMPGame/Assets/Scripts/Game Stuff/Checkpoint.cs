using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public VectorValue playerStorage;
    public Vector2Value cameraStorage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraMovement cam = Camera.main.GetComponent<CameraMovement>();
            SavedData.SaveData(playerStorage, collision.gameObject.transform.position, cameraStorage, cam.minPosition, cam.maxPosition);
            SoundManager.PlaySound("campfire");
            Debug.Log("Saved!");
        }
    }
}
