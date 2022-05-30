using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAndScoreManager : MonoBehaviour
{
    public int score = 0;
    public float time = 60;
    private int intTime;

    private bool startTimer;
    public GameObject endMenu;
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text endScoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
            time = time - Time.deltaTime;

        intTime = (int)time;

        timeText.text = intTime.ToString("000");
        scoreText.text ="SCORE : " + score.ToString("00");

        if (time <= 0)
        {
            endMenu.SetActive(true);
            endScoreText.text = score.ToString();
        }
    }

    public void IncreaseScore(int num)
    {
        score += num;
        time += 5;
    }

    public void StartTime()
    {
        startTimer = true;
    }
}
