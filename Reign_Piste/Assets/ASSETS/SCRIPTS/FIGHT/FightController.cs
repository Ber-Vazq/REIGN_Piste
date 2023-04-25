using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightController : MonoBehaviour
{
    // TODO: add the public and private variables
    [Header ("Public Variables")]
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;
    public TextMeshProUGUI playerDot;
    public TextMeshProUGUI enemyDot;
    public int playerScore;
    public int enemyScore;
    public float roundDelay = 2f;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    private int currentRound = 1;
    private float roundTime;
    private float timeRemaining;
    private bool isRoundOver;
    private bool isRoundActive;
    private bool playerWon;
    private bool enemyWon;
    //setting the variables i wrote down in my notes as the ones i think are going to be used 
    // at the least
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = roundTime;
        UpdateScoreUI();
        ResetRound();
    }

    // Update is called once per frame
    void Update()
    {
       if (isRoundActive)
       {
           timeRemaining -= Time.deltaTime;
           UpdateTimer();
       }
    }
    public void StartRound()
    {
        isRoundActive = true;
        isRoundOver = false;
        playerWon = false;
        enemyWon = false;

        player.GetComponent<playerController>().enabled = true;
        enemy.GetComponent<EnemyAI>().enabled = true;
        playerDot.gameObject.SetActive(true);
        enemyDot.gameObject.SetActive(true);
    }
    public void EndRound()
    {
        isRoundOver = true;
        isRoundActive = false;
        player.GetComponent<playerController>().enabled = false;
        enemy.GetComponent<EnemyAI>().enabled = false;
        playerDot.gameObject.SetActive(false);
        enemyDot.gameObject.SetActive(false);

        if(playerWon)
        {
            playerScore++;
        }
        else
        {
            enemyScore++;
        }

        UpdateScoreUI();

        if(currentRound == 3)
        {
            Debug.Log("Game Over");
        }
        else
        {
            Invoke("ResetRound", roundDelay);
        }
    }
    public void ResetRound()
    {
        isRoundActive = false;
        timeRemaining = roundTime;
        UpdateTimer();

        player.transform.position = new Vector3(-6.05f,-2.75f,0f);
        enemy.transform.position = new Vector3(5.71f,-2.75f,0f);

        currentRound++;

        StartRound();
    }
    private void UpdateTimer()
    {
        int seconds = Mathf.FloorToInt(timeRemaining % 30);
        string timeString = string.Format("{0:00}", seconds);
 //       playerDot.text = timeString;
//        enemyDot.text = timeString;

        if (timeRemaining <= 0 && !isRoundOver)
        {
            isRoundOver = true;
            if (player.transform.position.x < enemy.transform.position.x)
            {
                playerWon = true;
                Debug.Log("Player Wins Round " + currentRound);   
            }
            else
            {
                enemyWon = true;
                Debug.Log("Enemy Wins Round " + currentRound);
            }
        }
    }
    private void UpdateScoreUI()
    {
        playerScoreText.text = "Rounds Won: " + playerScore;
        enemyScoreText.text = "Rounds Won: " + enemyScore;
    }
}
//goign to finish this script to a workable condition tomorrow turning into bed it is 10:26 PM