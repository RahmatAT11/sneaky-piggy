using System.Collections;
using System.Collections.Generic;
using Controllers.Player;
using DragonBones;
using UnityEngine;
using UnityEngine.UI;

public class HidingManger : MonoBehaviour
{
    [SerializeField] private GameObject _buttonHide1, _buttonHide2;
    private GameObject _player;
    [SerializeField] private bool isMove, isUnhide;
    private int _playerLastOrderInLayer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _buttonHide1.SetActive(false);
        _buttonHide2.SetActive(false);

        isMove = false;
        isUnhide = true;
    }


    void Update()
    {
        if (isMove == true)
        {
            isUnhide = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _buttonHide1.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _buttonHide1.SetActive(false);
        }
    }

    public void isButtonHide1()
    {
        SoundManager.Instance.PlaySFX("SFX Hide In");
        isUnhide = false;

        if (isUnhide == false)
        {
            HidePlayer(true);

            _buttonHide1.SetActive(false);
            _buttonHide2.SetActive(true);
        } 
    }

    public void isButtonHide2()
    {
        SoundManager.Instance.PlaySFX("SFX Hide Out");
        isUnhide = true;

        if (isUnhide == true)
        {
            HidePlayer(false);

            _buttonHide1.SetActive(true);
            _buttonHide2.SetActive(false);
        }
    }

    private void HidePlayer(bool isHide)
    {
        PlayerController player = _player.GetComponent<PlayerController>();
        player.enabled = !isHide;
        if (isHide)
        {
            _player.layer = LayerMask.NameToLayer("Player");
            player.GetCurrentUac().sortingOrder = -5;
        }
        else
        {
            _player.layer = LayerMask.NameToLayer("Objects");
            player.GetCurrentUac().sortingOrder = 3;
        }
    }

}
