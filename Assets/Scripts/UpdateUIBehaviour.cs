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
	    roundNum = 1;
	}

    public void UpdateRoundNumberText()
    {
        if (roundNum < 3)
        {
            roundNum += 1;
        }

        RoundNumberText.text = "Round: " + roundNum;
    }

    int round2Score = 0;

    public void updateRoundScoreText()
    {
        Debug.Log("update score event");
        RoundScores.Add(playerScore.currentRoundScore);
        RoundScoreText.text = "Scores\n" + "R1: " + playerScore.currentRoundScore + "\t";
        if (roundNum == 2)
        {
            RoundScoreText.text += "R2: " + playerScore.currentRoundScore + "\t";
            Debug.Log("Current score" + playerScore.currentRoundScore);
            round2Score = playerScore.currentRoundScore;
        }

        if (roundNum == 3)
        {
            RoundScoreText.text += "R2: " + round2Score + "\t";
            RoundScoreText.text += "R3: " + playerScore.currentRoundScore;
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
