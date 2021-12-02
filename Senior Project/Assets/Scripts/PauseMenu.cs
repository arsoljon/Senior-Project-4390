using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused= false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) { Resume(); }
            else { Pause(); }
        }
    }

    void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = 0f;
    }
}
