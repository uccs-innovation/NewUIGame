using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GamepadSchemeSelect : MonoBehaviour
{
    UnityEvent finishedEvent = new UnityEvent();
    playerController playerController;

    [SerializeField]
    GameObject firstSelected;

    [SerializeField]
    GameObject text;

    TextMeshProUGUI TMText;

    private void Start()
    {
        // Select first button
        EventSystem.current.SetSelectedGameObject(firstSelected);
        TMText = text.GetComponent<TextMeshProUGUI>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }
    public void OnSchemeOneSelected()
    {
        PlayerPrefs.SetString("ControlScheme", "Standard");
        playerController.SetControlScheme(new InputBinding { groups = "Standard" });
        TMText.text = "Scheme 1 Selected";
        MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeTwoSelected()
    {
        PlayerPrefs.SetString("ControlScheme", "ShootButtonSwitched");
        playerController.SetControlScheme(new InputBinding { groups = "ShootButtonSwitched" });
        TMText.text = "Scheme 2 Selected";
        MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeThreeSelected()
    {
        PlayerPrefs.SetString("ControlScheme", "ShootButtonSwitched");
        playerController.SetControlScheme(new InputBinding { groups = "ShootButtonSwitched" });
        TMText.text = "Scheme 3 Selected";
        MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnBackSelected()
    {
        finishedEvent.Invoke();
    }

    public void AddHandler(UnityAction handler)
    {
        finishedEvent.AddListener(handler);
    }
}
