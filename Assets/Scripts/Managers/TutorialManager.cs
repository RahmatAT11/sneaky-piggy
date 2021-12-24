using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel1, tutorialPanel2, tapTutorialPanel1, tapTutorialPanel2;
    private BoxCollider2D Tutorial2Area;
    void Start()
    {
        tutorialPanel1.SetActive(true);
        tapTutorialPanel1.SetActive(true);
        tutorialPanel2.SetActive(false);
        tapTutorialPanel2.SetActive(false);
        Time.timeScale = 0f;

        Tutorial2Area = gameObject.GetComponent<BoxCollider2D>();
    }

    public void TapScreenTutorial1()
    {
        tutorialPanel1.SetActive(false);
        tapTutorialPanel1.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TapScreenTutorial2()
    {
        tutorialPanel2.SetActive(false);
        tapTutorialPanel2.SetActive(false);
        Time.timeScale = 1f;
    }

    void ShowingTutorialPanel2()
    {
        tutorialPanel1.SetActive(false);
        tapTutorialPanel1.SetActive(false);
        tutorialPanel2.SetActive(true);
        tapTutorialPanel2.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            ShowingTutorialPanel2();
            Tutorial2Area.isTrigger = true;
        }
    }

}
