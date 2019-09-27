using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ghostCatcher : MonoBehaviour
{
    static UnityEvent fallenGhost = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fallenGhost.Invoke();
        }
    }

    // Adds listeners for the when the ghost falls from a platform
    public static void AddFallenGhostListener(UnityAction handler)
    {
        fallenGhost.AddListener(handler);
    }
}
