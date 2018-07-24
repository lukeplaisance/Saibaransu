using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[CreateAssetMenu]
public class ScoreReference : ScriptableObject
{
    public List<int> Scores;
    public int CurrentRoundScore;
    public int TotalScore;

    public void Reset()
    {
        Scores = new List<int>();
        CurrentRoundScore = 0;
        TotalScore = 0;
    }
}
