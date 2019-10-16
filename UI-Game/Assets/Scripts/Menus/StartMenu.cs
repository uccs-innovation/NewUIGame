using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    AudioSource mouseOver;

    private void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();

        // Assign first audiosource attached to the gameobject
        mouseOver = sources[0];
    }
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

    public void OnMouseOver()
    {
        mouseOver.Play();
    }
}
