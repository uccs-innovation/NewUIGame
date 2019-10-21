using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControlSchemeSelect : MonoBehaviour
{
    UnityEvent finishedEvent = new UnityEvent();
    playerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }
    public void OnSchemeOneSelected()
    {
        PlayerPrefs.SetString("KeyboardScheme", "Keyboard_1");
        playerController.SetControlScheme(new InputBinding { groups = "Keyboard_1"});
        //MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeTwoSelected()
    {
        PlayerPrefs.SetString("KeyboardScheme", "Keyboard_2");
        playerController.SetControlScheme(new InputBinding { groups = "Keyboard_2" });
        //MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeThreeSelected()
    {
        PlayerPrefs.SetString("KeyboardScheme", "Keyboard_3");
        playerController.SetControlScheme(new InputBinding { groups = "Keyboard_3"});
        //MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnBackSelected()
    {
        MenuButtonSelected.PlayMenuButtonSelectedSound();
        finishedEvent.Invoke();
    }

    public void AddHandler(UnityAction handler)
    {
        finishedEvent.AddListener(handler);
    }
}
