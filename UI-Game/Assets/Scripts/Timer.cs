using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerUI;

    [SerializeField]
    GameObject timerText;

    int tenthSecondsPassed = 0;
    int secondsPassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        timerUI = timerText.GetComponent<TextMeshProUGUI>();
        ResetTimer();
    }

    void ResetTimer()
    {
        StopCoroutine("TenthSecondTimer");
        StartCoroutine("TenthSecondTimer");
    }

    IEnumerator TenthSecondTimer()
    {
        yield return new WaitForSeconds(.1f);

        string seconds = secondsPassed.ToString();
        if (secondsPassed < 10) seconds = "0" + seconds;

        string hundredthSeconds = tenthSecondsPassed.ToString();
        timerUI.text = seconds + "." + hundredthSeconds;

        tenthSecondsPassed++;
        if (tenthSecondsPassed > 9)
        {
            secondsPassed++;
            tenthSecondsPassed = 0;
        }

        ResetTimer();
    }
}
