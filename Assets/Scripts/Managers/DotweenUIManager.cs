using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
