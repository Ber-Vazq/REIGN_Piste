using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int currentRound = 1;
    private float timeRemaining;
    private bool isRoundOver;
    private bool isRoundActive;
    private bool playerWon;
    private bool enemyWin;
    //setting the variables i wrote down in my notes as the ones i think are going to be used 
    // at the least
    // Start is called before the first frame update
    void Start()
    {
        timeRemaing = roundTime;
        UpdateScoreUI();
        ResetRound();
    }

    // Update is called once per frame
    void Update()
    {
       timeRemaining
    }
    public void StartRound()
    {
        // TODO: add mechanics
    }
    public void EndRound()
    {
        // TODO: add mechanics
    }
    public void ResetRound()
    {
        // TODO: add the mechanics here
    }
    private void UpdateTimer()
    {
        Timer();
    }
    private void UpdateScoreUI()
    {
        playerScoreText.text = "Rounds Won: " + playerScore;
        enemyScoreText.text = "Rounds Won: " + enemyScore;
    }
}
//goign to finish this script to a workable condition tomorrow turning into bed it is 10:26 PM