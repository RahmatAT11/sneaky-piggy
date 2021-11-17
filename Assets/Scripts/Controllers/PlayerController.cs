using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseCharController
{
<<<<<<< HEAD
    [Header("Treasure Magnetic")]
    GameObject treasureMagnetic;
    Text treasureInfo;
    int treasureNumber;

    [Header("Collected UI")]
    public Image filledCollectedUI;
    float treasureCount;
    GameObject Treasure;

    private void Start()
    {
        treasureMagnetic = GameObject.Find("Treasure Magnetic");
        treasureInfo = GameObject.Find("Treasure Info").GetComponent<Text>();
        filledCollectedUI = GameObject.Find("CollectedFill").GetComponent<Image>();
        Treasure = GameObject.Find("Treasure");

        treasureCount = Treasure.transform.childCount;
        filledCollectedUI.fillAmount = 0;
    }

=======
    private GameJoystickController _joystick;
    
>>>>>>> feature-enemy
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _joystick = FindObjectOfType<GameJoystickController>();
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        MovementDirection.Set(xAxis, yAxis, 0f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            return;
        }

        isSprinting = false;

        TreasureMagneticPick();
    }

    private void FixedUpdate()
    {
        Walking();
        Turning();
        Sprinting();
    }
    void TreasureMagneticPick()
    {
        treasureInfo.text = treasureNumber.ToString();
        filledCollectedUI.fillAmount = treasureNumber * (1 / treasureCount);

        treasureMagnetic.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals ("Treasure"))
        {
            Destroy(col.gameObject);
            treasureNumber += 1;
        }
    }
}
