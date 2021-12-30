using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] levelButton;
    [SerializeField] public GameObject[] lockedButton;
    [SerializeField] private GameObject[] starAtLevel;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                levelButton[i].interactable = false;
                lockedButton[i].SetActive(true);
            }
        }

        int starValueCounter1 = PlayerPrefs.GetInt("LevelChapter 1 (1)");
        int starValueCounter2 = PlayerPrefs.GetInt("LevelChapter 1 (2)");
        int starValueCounter3 = PlayerPrefs.GetInt("LevelChapter 1 (3)");

        StarLevel(starAtLevel[0], starValueCounter1);
        StarLevel(starAtLevel[1], starValueCounter2);
        StarLevel(starAtLevel[2], starValueCounter3);
    }

    void StarLevel(GameObject StarLevel, int starValue)
    {
        if (starValue == 3)
        {
            StarLevel.transform.GetChild(0).gameObject.SetActive(true);
            StarLevel.transform.GetChild(1).gameObject.SetActive(true);
            StarLevel.transform.GetChild(2).gameObject.SetActive(true);
        }

        if (starValue == 2)
        {
            StarLevel.transform.GetChild(0).gameObject.SetActive(true);
            StarLevel.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (starValue == 1)
        {
            StarLevel.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (starValue == 0)
        {
            StarLevel.transform.GetChild(0).gameObject.SetActive(false);
            StarLevel.transform.GetChild(1).gameObject.SetActive(false);
            StarLevel.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
