using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI message;

    bool isChanging = false;

    public void OnBackClicked()
    {
        SceneManager.LoadScene("Start");
    }

    public void SchemeOneSelected()
    {
        ControlScheme.MoveLeft = KeyCode.A;
        ControlScheme.MoveRight = KeyCode.D;
        ControlScheme.Jump = KeyCode.W;
        ControlScheme.Shoot = KeyCode.Space;
        message.text = "Scheme 1 selected";
    }

    public void SchemeTwoSelected()
    {
        ControlScheme.MoveLeft = KeyCode.LeftArrow;
        ControlScheme.MoveRight = KeyCode.RightArrow;
        ControlScheme.Jump = KeyCode.UpArrow;
        ControlScheme.Shoot = KeyCode.Mouse0;
        message.text = "Scheme 2 selected";
    }

    public void SchemeThreeSelected()
    {
        ControlScheme.MoveLeft = KeyCode.A;
        ControlScheme.MoveRight = KeyCode.D;
        ControlScheme.Jump = KeyCode.W;
        ControlScheme.Shoot = KeyCode.Mouse0;
        message.text = "Scheme 3 selected";
    }
}
