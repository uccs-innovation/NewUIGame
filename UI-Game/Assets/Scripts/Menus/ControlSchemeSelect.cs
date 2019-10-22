using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class ControlSchemeSelect : MonoBehaviour
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
        PlayerPrefs.SetString("KeyboardScheme", "Keyboard_1");
        playerController.SetControlScheme(new InputBinding { groups = "Keyboard_1"});
        TMText.text = "Scheme 1 Selected";
        MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeTwoSelected()
    {
        PlayerPrefs.SetString("KeyboardScheme", "Keyboard_2");
        playerController.SetControlScheme(new InputBinding { groups = "Keyboard_2" });
        TMText.text = "Scheme 2 Selected";
        MenuButtonSelected.PlayMenuButtonSelectedSound();
    }

    public void OnSchemeThreeSelected()
    {
        PlayerPrefs.SetString("KeyboardScheme", "Keyboard_3");
        playerController.SetControlScheme(new InputBinding { groups = "Keyboard_3" });
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
