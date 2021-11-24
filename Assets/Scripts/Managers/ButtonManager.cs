using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject soundOnButton, soundOffButton, pauseButton, pausePanel;
    
    public void PauseButton()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }

    public void SettingButton()
    {

    }

    public void MainMenuButton()
    {
        
    }

    public void AdjustButton()
    {

    }

    public void StoreButton()
    {

    }

    public void SoundOnButton()
    {
        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
    }

    public void SoundOffButton()
    {
        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
    }
}
