using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject placeholder;

    [SerializeField]
    GameObject portalButton;

    [SerializeField]
    GameObject portalPanel;

    List<ScriptableObject> portals;

    private void Start()
    {
        GameObject pbutton = Instantiate(portalButton, portalPanel.transform);
        pbutton.name = "lvl_1";
        pbutton.GetComponent<Button>().onClick.AddListener(OnLevelSelected);

        GameObject button = Instantiate(placeholder, portalPanel.transform);
        button.name = "lvl_2";
        button.GetComponent<Button>().onClick.AddListener(OnLevelSelected);
    }
    public void OnLevelSelected()
    {
        // Get a reference to the currently selected button
        GameObject callingButton = EventSystem.current.currentSelectedGameObject;

        string sceneToLoad = GetScene(callingButton);

        SceneManager.LoadScene(sceneToLoad);
    }

    string GetScene(GameObject callingObject)
    {
        return ("MainScene");
    }
}
