using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyMode : MonoBehaviour
{
    public LevelGenerator levelGenerator;
    public float counter;
    public int currentPoints;

    void Start()
    {
        counter = 60;
        currentPoints = 0;
        levelGenerator.GenerateLevel();
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
        // TODO: Show end screen
        Debug.Log("You have " + levelGenerator.levelStars + " stars");
    }

    void GuessLiquid()
    {
        levelGenerator.OnGuessButtonClicked();
    }

    void SkipLevel()
    {
        Lose();
    }
}