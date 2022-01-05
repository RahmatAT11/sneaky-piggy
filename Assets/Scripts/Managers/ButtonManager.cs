using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject soundOnButton, soundOffButton, effectsOnButton, effectsOffButton, pauseButton;
    [SerializeField] private AudioClip buttonSource;

    [SerializeField] private CanvasGroup controllerUIPanel, pausePanel, storePanel, optionsPanel, QuitWarningPanel, pauseParentPanel;

    [SerializeField] private DotweenUIManager DOTweenManager;


    private void Start()
    {
        DOTweenManager = GetComponent<DotweenUIManager>();
        print(SceneManager.GetActiveScene().name);
        if (PlayerPrefs.GetInt("isMusicMute") == 1)
        {
            soundOnButton.SetActive(false);
            soundOffButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("isMusicMute") == 0)
        {
            soundOnButton.SetActive(true);
            soundOffButton.SetActive(false);
        }
    }

    private void Update()
    {
        
    }

    public void PauseButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(PauseButtonIsAnim(0.4f));
        Time.timeScale = 0f;
    }

    private IEnumerator PauseButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(controllerUIPanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(pausePanel, duration));
        pauseParentPanel.gameObject.SetActive(true);
    }

    public void ResumeButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(ResumeButtonIsAnim(0.4f));
        Time.timeScale = 1f;
    }

    private IEnumerator ResumeButtonIsAnim(float duration)
    {
        pauseParentPanel.gameObject.SetActive(false);
        StartCoroutine(DOTweenManager.FadeOut(pausePanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(controllerUIPanel, duration));
    }

    public void RestartButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SettingButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(SettingButtonIsAnim(0.4f));
    }

    private IEnumerator SettingButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(pausePanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(optionsPanel, duration));
    }

    public void BackSettingButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(BackSettingButtonIsAnim(0.4f));
    }

    private IEnumerator BackSettingButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(optionsPanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(pausePanel, duration));
    }

    public void MainMenuButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SoundManager.Instance.PlayBGM("BGM Source");
        
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void AdjustButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
    }

    public void StoreButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(StoreButtonIsAnim(0.4f));
    }

    private IEnumerator StoreButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(pausePanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(storePanel, duration));
    }

    public void BackStoreButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(BackStoreButtonIsAnim(0.4f));
    }

    private IEnumerator BackStoreButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(storePanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(pausePanel, duration));
    }

    public void SoundOnButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SoundManager.Instance.ToggleMusic(true);
        PlayerPrefs.SetInt("isMusicMute", 0);
        print(PlayerPrefs.GetInt("isMusicMute"));

        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
    }

    public void SoundOffButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SoundManager.Instance.ToggleMusic(false);
        PlayerPrefs.SetInt("isMusicMute", 1);
        print(PlayerPrefs.GetInt("isMusicMute"));

        soundOnButton.SetActive(true);
        soundOffButton.SetActive(false);
    }

    public void EffectsOnButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SoundManager.Instance.ToggleEffects(true);

        effectsOnButton.SetActive(false);
        effectsOffButton.SetActive(true);
    }

    public void EffectsOffButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SoundManager.Instance.ToggleEffects(false);

        effectsOnButton.SetActive(true);
        effectsOffButton.SetActive(false);
    }

    public void AboutButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
    }

    public void QuitButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(QuitButtonIsAnim(0.4f));
    }

    private IEnumerator QuitButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(optionsPanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(QuitWarningPanel, duration));
    }

    public void NoQuitButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(NoQuitButtonIsAnim(0.4f));
    }

    private IEnumerator NoQuitButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(QuitWarningPanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(optionsPanel, duration));
    }

    public void YesQuitButton()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        Application.Quit();
    }

    public void NextLevel()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
    }

    //======= MAIN MENU =========
    [Header("Main Menu")]
    [SerializeField] private CanvasGroup mainMenuPanel, storePanelMenu, optionsPanelMenu, chapter1PanelMenu;
    [SerializeField] private RectTransform chapter1button, chapter2button, chapter3button, chapter4button;
    [SerializeField] private RectTransform level1button, level2button, level3button, level4button, level5button, level6button, level7button, level8button, level9button;

    public void StoreButtonMenu()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(StoreButtomMenuIsAnim(0.4f));
    }

    private IEnumerator StoreButtomMenuIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(mainMenuPanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(storePanelMenu, duration));
    }

    public void OptionsButtonMenu()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(OptionsButtonMenuIsAnim(0.4f));
    }

    private IEnumerator OptionsButtonMenuIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(mainMenuPanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(optionsPanelMenu, duration));
    }

    public void Chapter1Button()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(Chapter1ButtonIsAnim(0.4f));
    }

    private IEnumerator Chapter1ButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(mainMenuPanel, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(chapter1PanelMenu, duration));
        StartCoroutine(DOTweenManager.LevelSelectionScaleIn(level1button, level2button, level3button, level4button, level5button, level6button, level7button, level8button, level9button));
    }

    public void BackStoreButtonMenu()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(BackStoreButtonMenuIsAnim(0.4f));
    }

    private IEnumerator BackStoreButtonMenuIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(storePanelMenu, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(mainMenuPanel, duration));
        StartCoroutine(DOTweenManager.ChapterSelectionScaleIn(chapter1button, chapter2button, chapter3button, chapter4button));
    }

    public void BackOptionsButtonMenu()
    {
        
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(BackOptionsButtonMenuIsAnim(0.4f));
    }

    private IEnumerator BackOptionsButtonMenuIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(optionsPanelMenu, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(mainMenuPanel, duration));
        StartCoroutine(DOTweenManager.ChapterSelectionScaleIn(chapter1button, chapter2button, chapter3button, chapter4button));
    }

    public void BackChapter1Button()
    {
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        StartCoroutine(BackChapter1ButtonIsAnim(0.4f));
    }

    private IEnumerator BackChapter1ButtonIsAnim(float duration)
    {
        StartCoroutine(DOTweenManager.FadeOut(chapter1PanelMenu, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(DOTweenManager.FadeIn(mainMenuPanel, duration));
        StartCoroutine(DOTweenManager.ChapterSelectionScaleIn(chapter1button, chapter2button, chapter3button, chapter4button));
    }

    public void Level1Button()
    {
        SoundManager.Instance.PlayBGM("BGM Diluar Rumah");
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SceneManager.LoadScene(1);
    }

    public void Level2Button()
    {
        SoundManager.Instance.PlayBGM("BGM Diluar Rumah");
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SceneManager.LoadScene(2);
    }

    public void Level3Button()
    {
        SoundManager.Instance.PlayBGM("BGM Diluar Rumah");
        SoundManager.Instance.PlaySFX("SFX Button Touch");
        SceneManager.LoadScene(3);
    }
}
