using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int score;
    public Text ScoreText;
    void Start()
    {
        score = 0;
    }

    
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
