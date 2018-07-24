using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Score : MonoBehaviour
{
    public ScoreReference highScore;
    public Text scoreText;
    public Text RoundOneScore;
    public Text RoundTwoScore;
    public Text RoundThreeScore;
    private void Start()
    {
        scoreText.text = " -High Score- \n" + highScore.Scores.Sum().ToString();
        RoundOneScore.text = " Round 1 : " + highScore.Scores[0].ToString();
        RoundTwoScore.text = " Round 2 : " + highScore.Scores[1].ToString();
        RoundThreeScore.text = " Round 3 : " + highScore.Scores[2].ToString();
    }
}
