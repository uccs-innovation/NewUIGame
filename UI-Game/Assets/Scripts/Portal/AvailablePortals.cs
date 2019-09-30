using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePortals : SingletonBehavior<AvailablePortals>
{
    // The complete list of portals that the player can be rewarded
    [SerializeField]
    List<LevelObject> allPortals;

    // The list of portals that the player has been rewarded
    List<LevelObject> availablePortals = new List<LevelObject>();

    // The active portal that the player is currently in
    LevelObject activePortal;

    private void Start()
    {
        // If there are no available portals for the player, then let's give him the first one off the list
        if (availablePortals.Count < 1)
        {
            availablePortals.Add(allPortals[0]);
        }
    }

    public void AwardPortal(LevelObject portal)
    {
        availablePortals.Add(portal);
    }

    public List<LevelObject> GetPortals()
    {
        return availablePortals;
    }

    public LevelObject ActivePortal
    {
        get { return activePortal; }
        set { activePortal = value; }
    }
       
}
