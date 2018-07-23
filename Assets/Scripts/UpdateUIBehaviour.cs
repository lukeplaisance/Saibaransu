using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIBehaviour : MonoBehaviour
{
    public List<int> RoundScores;

    public Text RoundScoreText;

    public Text RoundNumberText;

    public Text TotalScoreText;

	void Start () {
		
	}

    public void UpdateRoundNumberText()
    {

    }

    public void updateRoundScoreText()
    {

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
