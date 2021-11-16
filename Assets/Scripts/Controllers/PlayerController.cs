using UnityEngine;

public class PlayerController : BaseCharController
{
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate()
    {
        Walking();
        Turning();
        Sprinting();
    }
}
