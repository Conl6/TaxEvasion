using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [Header("Score")]
    private float totalScore;
    private float score;
    private float points; //points are to be allocated for other tasks such as killing enemy or what ever
    public float pointsPer;
    [Header("Timer")]
    private float timer;
    public float timePer;
    [Header("Text")]
    public TextMeshProUGUI scoreCountText;

    private void Update()
    {
        UpdateScoreText();
        totalScore = score + points;
        timer += Time.deltaTime;

        if (timer > timePer)
        {

            score += pointsPer;
            timer = 0;
        }
    }

    private void UpdateScoreText()
    {

        scoreCountText.text = "Points: " + totalScore;

    }
}
