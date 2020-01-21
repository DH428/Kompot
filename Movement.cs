using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb, MoveCamera;
    public float moveSpeed = 15f;
    public bool jump = false;
    public float jumpVelocity = 100f;
    public float drag = 0.775f; //norm 0.775f
    public int CoolDownFinish = 1;
    public int speed = 10; //max run speed
    public bool Airborne = true; //some bugfixes
    public float SpeedMult = 1f;
    public float JumpMult = 1f;
    public bool pressed;
    public Slider ssjkösjöklfdsgjlök;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Spawner.DoneLoad)
        {
            Controls();
        }

        if (Collectable.Boost || MenuSwitch.ConsoleBoostBool)
        {
            SpeedMult = 1.5f;
            JumpMult = 1.5f;
        }

        else
        {
            SpeedMult = 1f;
            JumpMult = 1f;
        }

        CameraMove();
    }

    public IEnumerator OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "lvlEnd" && Collectable.score >= Spawner.HowManyShrimsYouHaveToEat/2)
        {
            yield return new WaitForSeconds(CoolDownFinish);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.tag == "Floor")
        {
            jump = true;
            Airborne = false;
        }

        if (!collision.gameObject)
        {
            Airborne = true;
        }

        yield return null;
    }

    void Controls()
    {
        if (Input.GetKey("space") && jump == true && Airborne == false)
        {
            jump = false;
            Airborne = true;
            rb.AddForce(new Vector2(0, jumpVelocity * JumpMult));
        }

        if (Input.GetKey("d") && rb.velocity.x < speed * SpeedMult)
        {
            rb.AddForce(new Vector2(moveSpeed * SpeedMult, 0));
        }

        if (Input.GetKey("a") && rb.velocity.x > -speed * SpeedMult)
        {
            rb.AddForce(new Vector2(-moveSpeed * SpeedMult, 0));
        }

        if(Input.touchCount == 1 || pressed)
        {
            SliderControls(ssjkösjöklfdsgjlök);
        }
        else
        {
            ssjkösjöklfdsgjlök.value = 0;
        }
    }

    public void SliderControls(Slider slideVal)
    {
        if (rb.velocity.x > -speed * SpeedMult && rb.velocity.x < speed * SpeedMult)
        {
            rb.AddForce(new Vector2(moveSpeed * SpeedMult * slideVal.value, 0));
        }
    }
    
    public void JumpButton()
    {
        if (jump == true && Airborne == false)
        {
            jump = false;
            Airborne = true;
            rb.AddForce(new Vector2(0, jumpVelocity * JumpMult));
        }
    }

    public void CameraMove()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            Physics2D.Raycast(rb.transform.position, touch.position, 10);
        }
    }
}