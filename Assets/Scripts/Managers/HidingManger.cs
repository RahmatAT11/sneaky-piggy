using System.Collections;
using System.Collections.Generic;
using Controllers.Player;
using DragonBones;
using UnityEngine;

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
        _player.GetComponent<PlayerController>().enabled = !isHide;
        if (isHide)
        {
            _player.layer = LayerMask.NameToLayer("Player");
            _player.GetComponentInChildren<UnityArmatureComponent>().sortingOrder = -1;
        }
        else
        {
            _player.layer = LayerMask.NameToLayer("Objects");
            _player.GetComponentInChildren<UnityArmatureComponent>().sortingOrder = 2;
        }
    }

}
