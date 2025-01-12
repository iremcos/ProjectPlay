using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ui_script : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject mainMenuUI;

    
    public Slider volumeSlider;

    private bool isPaused = false;

    void Start()
    {
        
        if (pauseMenuUI) pauseMenuUI.SetActive(false);
        if (settingsMenuUI) settingsMenuUI.SetActive(false);
        if (mainMenuUI) mainMenuUI.SetActive(SceneManager.GetActiveScene().name == "MainMenu");

        
        if (volumeSlider) volumeSlider.value = AudioListener.volume;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(sceneName);
    }

    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    
    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    
    public void CloseSettings()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}

