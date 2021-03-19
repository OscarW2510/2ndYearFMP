using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavedData
{
    public static void SaveData(VectorValue player, Vector2 playerPosition, Vector2Value camera, Vector2 cameraMinPosition, Vector2 cameraMaxPosition)
    {
        player.initialValue = playerPosition;
        camera.minValue = cameraMinPosition;
        camera.maxValue = cameraMaxPosition;
    }
}
