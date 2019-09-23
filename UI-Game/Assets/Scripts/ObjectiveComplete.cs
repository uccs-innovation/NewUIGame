using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveComplete : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        Cursor.visible = true;
        OnContinueButtonPressed();
    }
    public void OnContinueButtonPressed()
    {
        SceneManager.LoadScene("Start");
    }
}
