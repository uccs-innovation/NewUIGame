using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectiveComplete : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI finalScoreObject;

    [SerializeField]
    TextMeshProUGUI speedBonusObject;

    int speedBonusMultiplier = 1000;

    [SerializeField]
    float slowTime = 120f; // In seconds

    [SerializeField]
    float fastTime = 5f; // In seconds

    ScoreController scoreController;
    Timer timer;

    private void Start()
    {
        scoreController = GameObject.FindGameObjectWithTag("scoreController").GetComponent<ScoreController>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        Cursor.visible = true;
        Time.timeScale = 0;

        DisplayFinalScore();
    }

    void DisplayFinalScore()
    {
        int rawScore = scoreController.Score;
        float time = timer.TimeLevelComplete;

        int speedBonus = CalculateSpeedBonus(time);
        int finalScore = CalculateFinalScore(rawScore, speedBonus);
        speedBonusObject.text = "+" + speedBonus + " speed bonus!";
        finalScoreObject.text = "Final Score: " + finalScore.ToString();
    }

    int CalculateFinalScore(int rawScore, int speedBonus)
    {
        return speedBonus + rawScore;
    }

    int CalculateSpeedBonus(float time)
    {
        float hTime = (time - fastTime) / (slowTime - fastTime);
        if (hTime < 0) hTime = 0;
        else if (hTime > 1) hTime = 1;
        return Mathf.RoundToInt((1 - hTime) * speedBonusMultiplier);
    }

    public void OnContinueButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
