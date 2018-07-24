using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private void Start()
    {
        scoreText.text = highScore.TotalScore.ToString();
    }

    public ScoreReference highScore;
    public Text scoreText;
}
