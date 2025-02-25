﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PelletController : MonoBehaviour
{
    [SerializeField]
    GameObject objComplete;

    List<GameObject> pelletList = new List<GameObject>();

    AudioSource pelletCollectedSound; 

    // **** THIS IS ACTUALLY GAME LOSE EVENT!!! ****
    UnityEvent GameWinEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        pelletCollectedSound = gameObject.GetComponent<AudioSource>();
        GameObject[] pellets = GameObject.FindGameObjectsWithTag("pellet");
        foreach (GameObject pellet in pellets)
        {
            pelletList.Add(pellet);
            pellet.GetComponent<Pellet>().AddCollectedListener(HandleCollectedPellet);
        }
    }

    void HandleCollectedPellet(GameObject pellet)
    {
        pelletCollectedSound.Play();
        pelletList.Remove(pellet);
        Destroy(pellet);

        if (pelletList.Count <= 0)
        {
            GameWinEvent.Invoke();
            GameObject win = Instantiate(objComplete);
        }
    }

    public void AddGameWinEventListener(UnityAction handler)
    {
        GameWinEvent.AddListener(handler);
    }
}
