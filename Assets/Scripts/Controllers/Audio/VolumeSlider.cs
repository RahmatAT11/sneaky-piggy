using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _optionPanel;

    private void Start()
    {
        //SoundManager.Instance.ChangeMasterVolume(_slider.value);
        _slider.value = PlayerPrefs.GetFloat("SliderVolumeValue");
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
    }

    private void Update()
    {
        if (_optionPanel.activeInHierarchy)
        {
            PlayerPrefs.SetFloat("SliderVolumeValue", _slider.value);
        }
    }

    public void SetSliderValue()
    {
        _slider.value = PlayerPrefs.GetFloat("SliderVolumeValue");
    }
}
