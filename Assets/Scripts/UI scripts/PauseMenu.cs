using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuButton;
    public GameObject pauseMenuExit;

    public string startingScene;

    public GameObject mainCamera;

    void Start()
    {
        // I'm so sorry
        RefreshButton refreshButton = mainCamera.GetComponent<RefreshButton>();
        tooltipPanel tooltipPanel = GetComponent<tooltipPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Starts game again and unfreezes time
        pauseMenuUI.SetActive(false);
        pauseMenuButton.SetActive(true);
        pauseMenuExit.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause()
    {
        // Pull up the pause overlay and freeze time
        if (!tooltipPanel.TooltipOn)
        {
            pauseMenuUI.SetActive(true);
            pauseMenuButton.SetActive(false);
            pauseMenuExit.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void RestartGame()
    {
        // This brings you back to the scene named in the 'Starting scene' public string in the editor
        SceneManager.LoadScene(startingScene);
        RefreshButton.GameIsReset = false;
    }

    public void QuitGame()
    {
        // Function to quit the game
        Application.Quit();
    }
}
