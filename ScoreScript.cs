using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score = Collectable.score;
    public Text scoreText;

    void FixedUpdate() //sync score board
    {
        scoreText.text = "Fruits: " + Collectable.score.ToString() + "/" + Spawner.HowManyShrimsYouHaveToEat.ToString() + "\n" + "Lifes: " + Life.life + "/3" + "\n" + "Vodka: " + Collectable.vodka;
    }

    public Text getScoreText()
    {
        return scoreText;
    }
}
