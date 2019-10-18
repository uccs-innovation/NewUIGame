using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaymodeSelect : MonoBehaviour
{
    AudioSource selected;

    private void Start()
    {
        selected = GetComponent<AudioSource>();
    }
    public void OnNormalModeSelected()
    {
        MenuButtonSelected.PlayMenuButtonSelectedSound();
        SceneManager.LoadScene("LevelSelect");
    }

    public void OnPortalPlaylistModeSelected()
    {
        MenuButtonSelected.PlayMenuButtonSelectedSound();
        SceneManager.LoadScene("PlaylistSelect");
    }

    public void OnBackSelected()
    {
        MenuButtonSelected.PlayMenuButtonSelectedSound();
        SceneManager.LoadScene("Start");
    }
}
