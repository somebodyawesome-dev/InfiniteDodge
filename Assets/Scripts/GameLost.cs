using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLost : MonoBehaviour
{
    [SerializeField] float restartDelay;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject player;
    [SerializeField] Joystick joystick;
    [SerializeField] Text scoreWhilePlaying;
    [SerializeField] Text scoreToDisplay;
    [SerializeField] Text highScoreToDisplay;
    public  void stopGame()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        joystick.enabled = false;
        float currentScore=gameManager.GetComponent<Scoring>().getScore();
        if (currentScore > SaveSystem.loadData().highScore)
        {
            SaveSystem.saveDate(currentScore);
        }
        highScoreToDisplay.text = SaveSystem.loadData().highScore.ToString("0");
        scoreToDisplay.text = currentScore.ToString("0");
        scoreWhilePlaying.enabled = false;
       
        gameManager.GetComponent<Scoring>().enabled = false;
        gameManager.GetComponent<SpawnObstacles>().enabled = false;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        
        foreach (GameObject ob in obstacles)
        {
            
            ob.GetComponent<MoveObstacle>().enabled = false;
        }
        player.GetComponent<PlayerManager>().dissolve();
        
        StartCoroutine(restart());
    }


    IEnumerator restart()
    {
        yield return new WaitWhile(player.GetComponent<PlayerManager>().isDissolving);
        gameOverPanel.SetActive(true);


    }
}
