using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool gamePaused = false;

    public void Start()
    {
        pauseMenu.SetActive(false);
    }


    public void Pause()
    {
        gamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneLoader.LoadScene(sceneID);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused == false)
                Pause();
            else
                Resume();
        }
        

    }

}
