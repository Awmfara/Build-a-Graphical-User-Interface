using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool GameIsPaused = false;
    [SerializeField]
    private GameObject pauseMenuUI = null;
    private string MainMenuScene = ("MainMenu");
    GameManager gameManager = null;
    [SerializeField]
    private GameObject gameManagerObject = null;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManagerObject = GameObject.FindWithTag("GameController");
    }


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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;


    }

    public void ReturntoMain()
    {
        Time.timeScale = 1f;
        Destroy(gameManagerObject);
        SceneManager.LoadScene(MainMenuScene);
        gameManager.iniTime = false;
    }


}
