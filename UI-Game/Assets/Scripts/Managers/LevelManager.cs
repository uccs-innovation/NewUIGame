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

    AvailablePortals availablePortals;

    private void Start()
    {
        availablePortals = GameObject.FindGameObjectWithTag("availablePortals").GetComponent<AvailablePortals>();
        portals = availablePortals.GetPortals();

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

        // Fill the row (if needed) for asthetic value
        if (portals.Count >= 5) return;

        for (int i = 0; i < (5 - portals.Count); i++)
        {
            Instantiate(placeholder, portalPanel.transform);
        }
    }

    public void OnLevelSelected()
    {
        // Get a reference to the currently selected button
        GameObject callingButton = EventSystem.current.currentSelectedGameObject;

        // The portal that the player selected to enter
        LevelObject currentPortal = FindPortal(callingButton);

        // Set portal as active in singleton availablePortals object
        availablePortals.ActivePortal = currentPortal;

        // Change the scene 
        SceneManager.LoadScene(currentPortal.sceneName);
    }


    // Finds the portal associated with a button
    LevelObject FindPortal(GameObject button)
    {
        foreach (LevelObject portal in portals)
        {
            if (button.name == portal.name)
            {
                return portal;
            }              
        }

        Debug.Log("Portal not found, please be sure to add it to list");
        return null;
    }
}
