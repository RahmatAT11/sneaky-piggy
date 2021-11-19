using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingManger : MonoBehaviour
{
    [SerializeField] private GameObject _buttonHide1, _buttonHide2;
    private GameObject _player;
    [SerializeField] private bool isMove, isUnhide;

    void Start()
    {
        _player = GameObject.Find("Character(Clone)");
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
        if (col.gameObject.name.Equals("Treasure Magnetic"))
        {
            _buttonHide1.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Treasure Magnetic"))
        {
            _buttonHide1.SetActive(false);
        }
    }

    public void isButtonHide1()
    {
        isUnhide = false;

        if (isUnhide == false)
        {
            _player.SetActive(false);

            _buttonHide1.SetActive(false);
            _buttonHide2.SetActive(true);

            Debug.Log("Hide");
        } 
    }

    public void isButtonHide2()
    {
        isUnhide = true;

        if (isUnhide == true)
        {
            _player.SetActive(true);

            _buttonHide1.SetActive(true);
            _buttonHide2.SetActive(false);

            Debug.Log("Unhide");
        }
    }

}
