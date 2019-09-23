using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour
{
    /* This dictionary takes a gameobject (navpoint) and returns a list of navpoints
       that this navpoint can reach via raycast
       Each list is grouped by the platform that it belongs to and sorted by distance from
       this navpoint */
    public static Dictionary<GameObject, List<GameObject>> navpointData = new Dictionary<GameObject, List<GameObject>>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Initializes the dictionary according to the platforms currently in the scene
    private Dictionary<GameObject, List<GameObject>> GetNavpointData ()
    {
        // This dictionary will be returned by the method
        Dictionary<GameObject, List<GameObject>> tempNavpointData = new Dictionary<GameObject, List<GameObject>>();

        // Get array of platforms currently in the scene
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("platform");

        // Loop through all platforms
        foreach (GameObject platform in platforms)
        {
            // Get array of all navpoints in current platform
            GameObject[] objects = platform.GetComponentsInChildren<GameObject>();

            // Create a list to hold this platform's navpoints
            List<GameObject> navpoints = new List<GameObject>();

            // Loop through all child gameobjects of platform
            foreach (GameObject obj in objects)
            {
                if (obj.tag == "navPoint") navpoints.Add(obj);
            }

            // write each platform as a key and its list of navpoints as the value
            tempNavpointData.Add(platform, navpoints);
        }

        // Return the dictionary
        return tempNavpointData;
    }

}
