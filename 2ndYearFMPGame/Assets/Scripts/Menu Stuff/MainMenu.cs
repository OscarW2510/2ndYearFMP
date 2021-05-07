using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int savedScene = 1;
    public void PlayGame()
    {
        SceneManager.LoadScene(savedScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
