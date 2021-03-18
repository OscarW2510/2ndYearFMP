using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    static GameStart instance;
    public Vector2 initialPlayerPosition;
    public Vector2 initialCameraMin;
    public Vector2 initialCameraMax;
    public VectorValue playerStorage;
    public Vector2Value cameraStorage;

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);

        playerStorage.initialValue = initialPlayerPosition;
        cameraStorage.minValue = initialCameraMin;
        cameraStorage.maxValue = initialCameraMax;
    }
}
