using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    float score;
    [SerializeField] Text scoreText;
    void Start()
    {
        score = 0;    
    }
   public float getScore()
    {
        return score;
    }
 
    void Update()
    {
        scoreText.text = score.ToString("0");
        score += Time.deltaTime * 2;
    }
}
