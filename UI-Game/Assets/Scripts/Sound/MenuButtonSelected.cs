using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonSelected : SingletonBehavior<MenuButtonSelected>
{
    static AudioSource menuButtonSelected;

    private void Start()
    {
        menuButtonSelected = GetComponent<AudioSource>();
    }

    public static void PlayMenuButtonSelectedSound()
    {
        menuButtonSelected.Play();
    }
}
