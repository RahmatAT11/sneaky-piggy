using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] levelButton;
    [SerializeField] public GameObject[] lockedButton;

    [SerializeField] public GameObject[] starUI;
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
    }
}
