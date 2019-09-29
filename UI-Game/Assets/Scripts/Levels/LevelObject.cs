using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelObject : ScriptableObject
{
    public string levelName = "Name of Level";

    // Icon sprite for the level
    public Sprite sprite;

    // Here we can include some spawner parameters to control the speed/difficulty of the level

    // The scene name of the level
    public string sceneName = "Scene name";

    // Description text for the level
    public string descrText = "A sentence or two that describes this level";

    // Speed bonus required to proceed to next level (portal)
    public int requiredSpeedBonus;

    // Score required to proceed to next level (portal)
    public int requiredScore;

    // This will be the portal (level) that the player is awarded for meeting the requirements to proceed
    // to the next level
    public LevelObject reward;

}
