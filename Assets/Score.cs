using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static int ScoreCount;

    void Start(){
        ScoreCount = 0;
    }

    void FixedUpdate(){
        scoreText.text =ScoreCount.ToString();
    }
}
