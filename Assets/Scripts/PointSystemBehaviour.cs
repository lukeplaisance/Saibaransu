using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSystemBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<int> pointsList = new List<int>();
    [SerializeField]
    private GameEvent gameEvent;
    public Text scoreTotalText;
    public Text currentRoundText;
    private int totalRounds = 3;
    private int currentRound = 0;
    private int ScoreToWin = 50;
    private int totalScore;

    public void AddPoints(int point)
    {
        pointsList.Add(point);
        SetTotalScore();
    }

    public void SetCurrentRound()
    {
        IncrementRound();
        currentRoundText.text = "Round: " + currentRound.ToString();
    }

    public void SetTotalScore()
    {
        totalScore = pointsList.Sum();
        scoreTotalText.text = "Total Score: " + totalScore.ToString();
    }

    public void IncrementRound()
    {
        currentRound++;
        if (currentRound >= 4)
        {
            SceneManager.LoadScene("GameEnd");
        }
    }

    //public void CheckForWinner()
    //{
    //    for(int i = 0; i < ScoreToWin; i++)
    //    {
    //        if(totalScore == ScoreToWin)
    //        {
                
    //        }
    //    }
    //}
}
