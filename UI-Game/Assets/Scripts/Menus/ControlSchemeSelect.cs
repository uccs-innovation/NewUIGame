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
        //PlayerPrefs.SetString("ControlScheme", "Standard");
        //playerController.SetControlScheme(new InputBinding { groups = "Standard" });
        //MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeTwoSelected()
    {
        //PlayerPrefs.SetString("ControlScheme", "ShootButtonSwitched");
        //playerController.SetControlScheme(new InputBinding { groups = "ShootButtonSwitched" });
        //MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeThreeSelected()
    {
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
