﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public void OnBackButtonPressed()
    {
        MenuButtonSelected.PlayMenuButtonSelectedSound();
        SceneManager.LoadScene("Start");
    }
}
