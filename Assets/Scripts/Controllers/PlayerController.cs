using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseCharController
{
    [Header("Treasure Magnetic")]
    private GameObject _treasureMagnetic;
    private Text _treasureInfo;
    private int _treasureNumber;

    [Header("Collected UI")]
    public Image filledCollectedUI;
    private float _treasureCount;
    private GameObject _treasure;

    private void Start()
    {
        _treasureMagnetic = GameObject.Find("Treasure Magnetic");
        _treasureInfo = GameObject.Find("Treasure Info").GetComponent<Text>();
        filledCollectedUI = GameObject.Find("CollectedFill").GetComponent<Image>();
        _treasure = GameObject.Find("Treasures");

        _treasureCount = _treasure.transform.childCount;
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
        _treasureInfo.text = _treasureNumber.ToString();
        filledCollectedUI.fillAmount = _treasureNumber * (1 / _treasureCount);

        _treasureMagnetic.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals ("Treasure"))
        {
            Destroy(col.gameObject);
            _treasureNumber += 1;
        }
    }
}
