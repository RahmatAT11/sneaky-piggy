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
        //StartCoroutine(BackChapter1ButtonIsAnim(0.4f));
    }

    public void PauseButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
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
        SoundManager.Instance.PlaySound(buttonSource);
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
        SoundManager.Instance.PlaySound(buttonSource);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SettingButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
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
        SoundManager.Instance.PlaySound(buttonSource);
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
        SoundManager.Instance.PlaySound(buttonSource);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void AdjustButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
    }

    public void StoreButton()
    {
        SoundManager.Instance.PlaySound(buttonSource);
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
        SoundManager.Instance.PlaySound(buttonSource);
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
        //SoundManager.Instance.PlaySound(buttonSource);
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
        //SoundManager.Instance.PlaySound(buttonSource);
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
        //SoundManager.Instance.PlaySound(buttonSource);
        Application.Quit();
    }

    public void NextLevel()
    {
        SoundManager.Instance.PlaySound(buttonSource);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
    }

    //======= MAIN MENU =========
    [Header("Main Menu")]
    [SerializeField] private CanvasGroup mainMenuPanel, storePanelMenu, optionsPanelMenu, chapter1PanelMenu;
    [SerializeField] private RectTransform chapter1button, chapter2button, chapter3button, chapter4button;
    [SerializeField] private RectTransform level1button, level2button, level3button, level4button, level5button, level6button, level7button, level8button, level9button;

    public void StoreButtonMenu()
    {
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
        SceneManager.LoadScene(1);
    }

    public void Level2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3Button()
    {
        SceneManager.LoadScene(3);
    }
}
