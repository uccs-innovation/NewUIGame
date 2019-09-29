using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject placeholder;

    [SerializeField]
    GameObject portalButton;

    [SerializeField]
    GameObject portalPanel;

    List<LevelObject> portals;

    private void Start()
    {
        portals = GameObject.FindGameObjectWithTag("availablePortals").GetComponent<AvailablePortals>().GetPortals();

        PopulateButtons();

    }

    void PopulateButtons()
    {
        // Levels and portals are the same thing
        foreach (LevelObject portal in portals)
        {
            GameObject button = Instantiate(portalButton, portalPanel.transform);
            button.name = portal.name;
            button.GetComponentInChildren<TextMeshProUGUI>().text = portal.levelName;
            button.GetComponent<Button>().onClick.AddListener(OnLevelSelected);
        }
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
