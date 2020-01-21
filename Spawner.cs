using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public float x, y;
    public GameObject PrefabWall, PrefabFloor, Finish, Fruit, Vodka;
    public int stuff = 30; //how many platforms on lvl
    public float distance = 5; //distance between platforms
    public static bool DoneLoad = false;
    public bool ShowGeneratingProcess = true; //delay while generating map
    public int maxHigh = 10; //highest platform spawn
    public static int HowManyShrimsYouHaveToEat; //how many fruits are there?
    public static int VodkaCount;
    public int chanceFruit = 7; //chance that a fruit will spawn
    public int chanceVodka = 1; //"stay away from my vodkaa!"

    //+-2.5 tolerance

    private IEnumerator Start()
    {
        HowManyShrimsYouHaveToEat = 0;
        VodkaCount = 0;

        for (int i = 0; i < stuff; i++) //generaing rng level
        {
            Instantiate(PrefabFloor, new Vector2(transform.position.x, y + 0.41f), Quaternion.identity);
            Instantiate(PrefabWall, new Vector2(transform.position.x, y), Quaternion.identity);

            if(ShowGeneratingProcess == true)
            {
                yield return new WaitForSeconds(0.1f); //visualize lvl generation
            }

            if (Random.Range(1, 100 / chanceFruit) == 1) //chance to generate fruit above platform
            {
                Instantiate(Fruit, new Vector2(transform.position.x, y+3), Quaternion.identity);
                HowManyShrimsYouHaveToEat++;
            }

            if (Random.Range(1, 100 / chanceVodka) == 1) //chance to generate fruit above platform
            {
                Instantiate(Vodka, new Vector2(transform.position.x, y + 1), Quaternion.identity);
                VodkaCount++;
            }

            transform.position = new Vector2(transform.position.x + distance, 0);
            y = Random.Range(-4f, maxHigh);
        }

        Instantiate(PrefabFloor, new Vector2(transform.position.x, y + 0.41f), Quaternion.identity);
        Instantiate(PrefabWall, new Vector2(transform.position.x, y), Quaternion.identity);
        Instantiate(Finish, new Vector2(transform.position.x, y+3), Quaternion.identity); //always generating finish
        DoneLoad = true; //allow movement
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("r") || Life.life < 0) //reload level
        {
            DoneLoad = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
