using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIBehaviour : MonoBehaviour
{
    public List<int> RoundScores;

    public int roundNum;

    public Text RoundScoreText;

    public Text RoundNumberText;

    public Text TotalScoreText;
    public List<Text> RoundScoresDisplay;

    public GameObject pointSystem;

    private PointSystemBehaviour playerScore;


    void Awake()
	{
	    playerScore = pointSystem.GetComponent<PointSystemBehaviour>();	    
	}

    public void UpdateRoundNumberText()
    {
        RoundNumberText.text = playerScore.currentRound.ToString();
    }

    private int round1Score = 0;
    private int round2Score = 0;

    public void updateRoundScoreText()
    {
        if (playerScore.currentRound == 1)
        {
            round1Score = playerScore.scores.CurrentRoundScore;
        }
        Debug.Log("update score event");
        RoundScores.Add(playerScore.scores.CurrentRoundScore);
        RoundScoresDisplay[0].text = "R1: " + playerScore.scores.CurrentRoundScore;
        if (playerScore.currentRound == 2)
        {
            RoundScoresDisplay[1].text = "R3: " + playerScore.scores.CurrentRoundScore;
            round2Score = playerScore.scores.CurrentRoundScore;
        }

        if (playerScore.currentRound == 3)
        {
            RoundScoresDisplay[2].text = "R3: " + playerScore.scores.CurrentRoundScore;
        }

    }

    public void UpdateTotalScoreText()
    {
        int total = 0;
        foreach (var score in RoundScores)
        {
            total += score;
        }

        TotalScoreText.text = "Score: " + total;
    }
}