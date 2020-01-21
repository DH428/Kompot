using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public static int life = 3;
    public Rigidbody2D rb;
    public float y = -20, NewPosX, NewPosY = 1;

    private void Start()
    {
        life = 3;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ded")
        {
            Restart();
        }


        if (collision.gameObject.tag == "CheckPoint")
        {
            NewPosX = transform.position.x;
            NewPosY = transform.position.y;
        }

        if (collision.gameObject.tag == "Life")
        {
            Destroy(collision.gameObject);
            if (life < 3)
            {
                life++;
            }
        }
    }

    public void FixedUpdate()
    {
        if (rb.transform.position.y < y)
        {
            Restart();
        }
    }

    void Restart()
    {
        if (!MenuSwitch.ConsoleGodModeBool)
        {
            life--;
        }

        transform.position = new Vector2(NewPosX, NewPosY);
        rb.velocity = new Vector2(0, 0);
    }
}
