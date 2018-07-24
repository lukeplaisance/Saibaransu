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
    }
