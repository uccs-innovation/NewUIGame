using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public void OnLevelOneSelected()
    {       
        SceneManager.LoadScene("MainScene");
    }
}
