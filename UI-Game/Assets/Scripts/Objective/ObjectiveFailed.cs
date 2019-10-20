using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectiveFailed : MonoBehaviour
{
    [SerializeField]
    GameObject resumeButton;

    // Start is called before the first frame update
    void Start()
    {
        resumeButton.GetComponent<Button>().Select();
        Cursor.visible = true;
        Time.timeScale = 0;
    }


    public void HandleContinue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }
}
