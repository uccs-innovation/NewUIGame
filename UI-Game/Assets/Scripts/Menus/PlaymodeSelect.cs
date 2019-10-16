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
        SceneManager.LoadScene("LevelSelect");
    }

    public void OnPortalPlaylistModeSelected()
    {
        SceneManager.LoadScene("PlaylistSelect");
    }

    public void OnBackSelected()
    {
        SceneManager.LoadScene("Start");
    }
}
