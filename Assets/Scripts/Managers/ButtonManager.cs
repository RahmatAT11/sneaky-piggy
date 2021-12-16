using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject soundOnButton, soundOffButton, effectsOnButton, effectsOffButton,
        pauseButton, pausePanel, settingPanel, storePanel;
    [SerializeField] private AudioClip buttonSource;

    [SerializeField] private RectTransform pausePanelRect;

    [SerializeField] private DotweenUIManager DOTweenManager;

    private void Start()
    {
        DOTweenManager = GetComponent<DotweenUIManager>();
    }

    public void PauseButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
        pauseButton.SetActive(false);

        StartCoroutine(DOTweenManager.AnimationSnapOut(pausePanelRect, 0.5f));
        
        //pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);

        pauseButton.SetActive(true);
        pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SettingButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);

        settingPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void BackSettingButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);

        settingPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void MainMenuButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
    }

    public void AdjustButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
    }

    public void StoreButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);

        storePanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void BackStoreButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);

        storePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void SoundOnButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
        SoundManager.Instance.ToggleMusic(true);

        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
    }

    public void SoundOffButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
        SoundManager.Instance.ToggleMusic(false);

        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
    }

    public void EffectsOnButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
        SoundManager.Instance.ToggleEffects(true);

        effectsOnButton.SetActive(false);
        effectsOffButton.SetActive(true);
    }

    public void EffectsOffButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
        SoundManager.Instance.ToggleEffects(false);

        effectsOnButton.SetActive(true);
        effectsOffButton.SetActive(false);
    }

    public void AboutButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
    }

    public void QuitButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
    }
}
