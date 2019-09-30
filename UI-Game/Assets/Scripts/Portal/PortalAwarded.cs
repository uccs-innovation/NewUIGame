using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PortalAwarded : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI portalAwardedMessage;

    AvailablePortals availablePortals;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to availablePortals singlton object
        availablePortals = GameObject.FindGameObjectWithTag("availablePortals").GetComponent<AvailablePortals>();

        // Get a reference to the reward for finishing the current level
        LevelObject newPortal = availablePortals.ActivePortal.reward;

        // Add the new portal to the available portals
        availablePortals.AwardPortal(newPortal);

        portalAwardedMessage.text = ("'" + newPortal.levelName + "' added to your collection");
    }

    public void OnContinueButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }
}
