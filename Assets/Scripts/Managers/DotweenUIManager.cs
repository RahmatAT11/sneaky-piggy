using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenUIManager : MonoBehaviour
{
    public IEnumerator FadeIn(CanvasGroup container, float duration)
    {
        container.gameObject.SetActive(true);
        container.alpha = 0f;
        yield return new WaitForSecondsRealtime(0);
        container.DOFade(1f, duration).SetUpdate(true);
    }

    public IEnumerator FadeOut(CanvasGroup container, float duration)
    {
        container.alpha = 1f;
        container.DOFade(0f, duration).SetEase(Ease.InQuint);
        yield return new WaitForSecondsRealtime(duration);
        container.gameObject.SetActive(false);
    }

    public IEnumerator ChapterSelectionScaleIn(RectTransform chapter1Container, RectTransform chapter2Container, RectTransform chapter3Container, RectTransform chapter4Container)
    {
        chapter1Container.gameObject.SetActive(true);
        chapter2Container.gameObject.SetActive(true);
        chapter3Container.gameObject.SetActive(true);
        chapter4Container.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0);
        chapter1Container.localScale = new Vector3(0, 0, 0);
        chapter2Container.localScale = new Vector3(0, 0, 0);
        chapter3Container.localScale = new Vector3(0, 0, 0);
        chapter4Container.localScale = new Vector3(0, 0, 0);

        chapter1Container.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.InOutExpo);
        chapter2Container.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetEase(Ease.InOutExpo);
        chapter3Container.DOScale(new Vector3(1f, 1f, 1f), 0.7f).SetEase(Ease.InOutExpo);
        chapter4Container.DOScale(new Vector3(1f, 1f, 1f), 0.9f).SetEase(Ease.InOutExpo);
    }

    public IEnumerator LevelSelectionScaleIn(RectTransform level1Container, RectTransform level2Container, RectTransform level3Container,
        RectTransform level4Container, RectTransform level5Container, RectTransform level6Container,
        RectTransform level7Container, RectTransform level8Container, RectTransform level9Container)
    {
        level1Container.gameObject.SetActive(true);
        level2Container.gameObject.SetActive(true);
        level3Container.gameObject.SetActive(true);
        level4Container.gameObject.SetActive(true);
        level5Container.gameObject.SetActive(true);
        level6Container.gameObject.SetActive(true);
        level7Container.gameObject.SetActive(true);
        level8Container.gameObject.SetActive(true);
        level9Container.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0);
        level1Container.localScale = new Vector3(0, 0, 0);
        level2Container.localScale = new Vector3(0, 0, 0);
        level3Container.localScale = new Vector3(0, 0, 0);
        level4Container.localScale = new Vector3(0, 0, 0);
        level5Container.localScale = new Vector3(0, 0, 0);
        level6Container.localScale = new Vector3(0, 0, 0);
        level7Container.localScale = new Vector3(0, 0, 0);
        level8Container.localScale = new Vector3(0, 0, 0);
        level9Container.localScale = new Vector3(0, 0, 0);

        level1Container.DOScale(new Vector3(1f, 1f, 1f), 0.2f).SetEase(Ease.InOutExpo);
        level2Container.DOScale(new Vector3(1f, 1f, 1f), 0.4f).SetEase(Ease.InOutExpo);
        level3Container.DOScale(new Vector3(1f, 1f, 1f), 0.6f).SetEase(Ease.InOutExpo);
        level4Container.DOScale(new Vector3(1f, 1f, 1f), 0.8f).SetEase(Ease.InOutExpo);
        level5Container.DOScale(new Vector3(1f, 1f, 1f), 1.0f).SetEase(Ease.InOutExpo);
        level6Container.DOScale(new Vector3(1f, 1f, 1f), 1.2f).SetEase(Ease.InOutExpo);
        level7Container.DOScale(new Vector3(1f, 1f, 1f), 1.4f).SetEase(Ease.InOutExpo);
        level8Container.DOScale(new Vector3(1f, 1f, 1f), 1.6f).SetEase(Ease.InOutExpo);
        level9Container.DOScale(new Vector3(1f, 1f, 1f), 1.8f).SetEase(Ease.InOutExpo);
        
        //next w rapihin :v
    }
    /*
    public IEnumerator AnimationWideIn(RectTransform container, float duration)
    {
        container.localScale = new Vector3(1, 1, 1);
        container.DOScale(new Vector3(0f, 1f, 1f), duration).SetUpdate(true);
        yield return new WaitForSecondsRealtime(duration);
        container.gameObject.SetActive(false);
    }

    public IEnumerator AnimationWideOut(RectTransform container, float duration)
    {
        container.localScale = new Vector3(0, 1, 1);
        container.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0);
        container.DOScale(new Vector3(1f, 1f, 1f), duration).SetUpdate(true);
        container.DOAnchorPosY(0f, duration).SetUpdate(true);
    }

    public IEnumerator AnimationSnapOut(RectTransform container, float duration)
    {
        container.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        container.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0);
        container.DOScale(new Vector3(1f, 1f, 1f), duration).SetUpdate(true);
        container.DOAnchorPosY(0f, duration).SetUpdate(true);
    }

    public IEnumerator AnimationSnapIn(RectTransform container, float duration)
    {
        container.localScale = new Vector3(1, 1, 1);
        container.DOScale(new Vector3(0.7f, 0.7f, 0.7f), duration).SetUpdate(true);
        container.DOAnchorPosY(-200, duration).SetUpdate(true);
        yield return new WaitForSecondsRealtime(duration);
        container.gameObject.SetActive(false);
    }*/
}
