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
    private GameEvent PointUpdate;    
    private int totalRounds = 3;
    public int currentRound = 1;
    private int ScoreToWin = 50;
    private int totalScore;
    public int currentRoundScore;

    public void AddPoints(int point)
    {
        pointsList.Add(point);
        SetTotalScore();
        currentRoundScore = point;
        PointUpdate.Raise();
    }

    public void SetCurrentRound()
    {
        IncrementRound();        
    }

    public void SetTotalScore()
    {
        totalScore = pointsList.Sum();        
    }

    public void IncrementRound()
    {        
        currentRound++;
        currentRoundScore = 0;
        if (currentRound >= 4)
        {
            SceneManager.LoadScene("3.GameOver");
        }
    }
}
