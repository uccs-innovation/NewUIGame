using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnInstructionsButtonClicked()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
