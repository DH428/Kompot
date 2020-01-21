using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static int score = 0, vodka = 0;
    public static bool Boost = false;
    public Rigidbody2D rb;

    private void Start()
    {
        score = 0;
        vodka = Spawner.VodkaCount;
    }
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            score++;
        }

        if (collision.gameObject.tag == "Vodka")
        {
            Destroy(collision.gameObject);
            vodka--;
            Boost = true;
            yield return new WaitForSeconds(10);
            Boost = false;
        }

        if (collision.gameObject.tag == "CheckPoint")
        {
            Destroy(collision.gameObject);
        }
    }
}
