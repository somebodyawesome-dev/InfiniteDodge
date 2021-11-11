using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public float highScore;
    public int donuts;
    public GameData(float score)
    {
        highScore = score;
        donuts = 0;
    }
    public GameData(float score,int donuts)
    {
        highScore = score;
        this.donuts = donuts;
    }

}
