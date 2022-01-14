using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel1, tapTutorialPanel1, indicatorStar;
    void Start()
    {
        tutorialPanel1.SetActive(true);
        tapTutorialPanel1.SetActive(true);
        indicatorStar.SetActive(false);
        Time.timeScale = 0f;
    }

    public void TapScreenTutorial1()
    {
        tutorialPanel1.SetActive(false);
        tapTutorialPanel1.SetActive(false);
        indicatorStar.SetActive(true);
        Time.timeScale = 1f;
    }

}
