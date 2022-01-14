using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManagerHide : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel2, tapTutorialPanel2;
    private BoxCollider2D Tutorial2Area;

    private void Start()
    {
        Tutorial2Area = gameObject.GetComponent<BoxCollider2D>();
        tutorialPanel2.SetActive(false);
        tapTutorialPanel2.SetActive(false);
    }

    public void TapScreenTutorial2()
    {
        tutorialPanel2.SetActive(false);
        tapTutorialPanel2.SetActive(false);
        Time.timeScale = 1f;
    }

    void ShowingTutorialPanel2()
    {
        tutorialPanel2.SetActive(true);
        tapTutorialPanel2.SetActive(true);
        Time.timeScale = 0f;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShowingTutorialPanel2();
            SoundManager.Instance.StopSFX("SFX Babi Jalan");
            SoundManager.Instance.StopSFX("SFX Babi Lari");
            Tutorial2Area.enabled = false;
            print("PPPPPPPPPP");
        }
    }

}
