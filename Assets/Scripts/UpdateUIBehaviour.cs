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

    public GameObject pointSystem;

    private PointSystemBehaviour playerScore;


    void Start ()
	{
	    playerScore = pointSystem.GetComponent<PointSystemBehaviour>();	    
	}

    public void UpdateRoundNumberText()
    {
        RoundNumberText.text = "Round: " + playerScore.currentRound;
    }

    private int round1Score = 0;
    private int round2Score = 0;

    public void updateRoundScoreText()
    {
        if (playerScore.currentRound == 1)
        {
            round1Score = playerScore.highScore.CurrentRoundScore;
        }
        Debug.Log("update score event");
        RoundScores.Add(playerScore.highScore.CurrentRoundScore);
        RoundScoreText.text = "Scores\n" + "R1: " + round1Score + "\t";
        if (playerScore.currentRound == 2)
        {
            RoundScoreText.text += "R2: " + playerScore.highScore.CurrentRoundScore + "\t";
            round2Score = playerScore.highScore.CurrentRoundScore; ;
        }

        if (playerScore.currentRound == 3)
        {
            RoundScoreText.text += "R2: " + round2Score + "\t";
            RoundScoreText.text += "R3: " + playerScore.highScore.CurrentRoundScore;
        }

    }

    public void UpdateTotalScoreText()
    {
        int total = 0;
        foreach (var score in RoundScores)
        {
            total += score;
        }

        TotalScoreText.text = "Total\n    Score: " + total;
    }
}
