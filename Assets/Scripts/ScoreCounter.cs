using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;
    private void Start()
    {
        score = 0;
    }
    public void ChangeScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: "+score.ToString();
    }
    
}
