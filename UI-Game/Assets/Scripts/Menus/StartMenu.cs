using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnInstructionsButtonPressed()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("PlaymodeSelect");
    }

    public void OnCreditsButtonClicked()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    public void OnOptionsClicked()
    {
        SceneManager.LoadScene("Options");
    }
}
