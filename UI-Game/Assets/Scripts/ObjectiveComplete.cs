using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveComplete : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine("Timer");
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void OnContinueButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
