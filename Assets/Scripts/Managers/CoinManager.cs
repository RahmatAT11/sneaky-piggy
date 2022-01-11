using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField] private Text coinText;
    public int coinValue;
    void Start()
    {
        //coinValue = 100;
        //PlayerPrefs.SetInt("Coin", coinValue);
    }

    void Update()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
