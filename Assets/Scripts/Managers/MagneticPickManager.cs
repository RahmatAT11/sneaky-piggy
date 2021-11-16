using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPickManager : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector2 playerDirection;
    float timeStamp;
    bool isMagnetic;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMagnetic)
        {
            playerDirection =- (transform.position - player.transform.position).normalized;

            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * 10f * (Time.time / timeStamp);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals ("Treasure Magnetic"))
        {
            timeStamp = Time.time;
            player = GameObject.Find("Character(Clone)");
            isMagnetic = true;
        }
    }
}
