using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
        }
    }
    public void GotToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
