using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelComplete;
    //public VectorValue playerPosition;
    public void GotToMainMenu()
    {
        //playerPosition.initialValue = FindObjectOfType<PlayerMovement>().transform.position;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
