using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreScrip : MonoBehaviour
{
    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            updateScoreText();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    public void updateScoreText()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreTextUI.text = scoreStr;
    }
}
