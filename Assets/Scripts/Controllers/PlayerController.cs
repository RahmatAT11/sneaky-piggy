using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseCharController
{
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
        Treasure = GameObject.Find("Treasures");

        treasureCount = Treasure.transform.childCount;
        filledCollectedUI.fillAmount = 0;
    }
    
    private GameJoystickController _joystick;
    
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _joystick = FindObjectOfType<GameJoystickController>();
    }

    private void Update()
    {
        ProcessInput();
        TreasureMagneticPick();
    }

    private void ProcessInput()
    {
        /*float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");*/
        
        float xAxis = _joystick.InputHorizontal();
        float yAxis = _joystick.InputVertical();

        MovementDirection.Set(xAxis, yAxis, 0f);
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
