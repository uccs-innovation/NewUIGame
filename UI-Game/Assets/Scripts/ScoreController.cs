using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    int score;

    [SerializeField]
    GameObject scoreAmountObject;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreAmountObject.GetComponent<TextMeshProUGUI>();

        Spawner.AddPointsGrantedListener(HandlePointsGranted);
    }

    void HandlePointsGranted(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public int Score
    {
        get { return score; }
    }
}
