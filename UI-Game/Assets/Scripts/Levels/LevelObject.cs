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

}
