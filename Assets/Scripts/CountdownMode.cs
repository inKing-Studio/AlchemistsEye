using System;
using System.Collections.Generic;
using UnityEngine;

public class CountdownMode : MonoBehaviour {
    public Level levelGenerator;
    public float counter;
    public int currentPoints;

    void Start()
    {
        counter = 60;
        currentPoints = 0;
    }

    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0) {
            Lose();
        }
    }

    void Lose()
    {
        // TODO: Show lose screen
        Debug.Log("You lose");
    }

    void GuessLiquid()
    {
        if (levelGenerator.levelStars >= 1) {
            counter += 10 * levelGenerator.levelStars;
            currentPoints += levelGenerator.levelStars;
        }
    }

    void SkipLevel()
    {
        //levelGenerator.GenerateLevel();
    }
}