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
    public ScoreReference scores;

    private void Awake()
    {
        scores.Reset();
    }

    public void AddPoints(int point)
    {
        pointsList.Add(point);
        SetTotalScore();
        scores.CurrentRoundScore = point;
        scores.Scores.Add(point);
        PointUpdate.Raise();
    }

    public void SetCurrentRound()
    {
        IncrementRound();        
    }

    public void SetTotalScore()
    {
        scores.TotalScore = scores.Scores.Sum();
    }

    public void IncrementRound()
    {        
        currentRound++;
        scores.CurrentRoundScore = 0;
        if (currentRound >= 4)
        {
            SceneManager.LoadScene("3.GameOver");
        }
    }
}
