using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pellet : MonoBehaviour
{
    PelletCollectedEvent collected = new PelletCollectedEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collected.Invoke(gameObject);
        }
    }

    public void AddCollectedListener(UnityAction<GameObject> handler)
    {
        collected.AddListener(handler);
    }
}
