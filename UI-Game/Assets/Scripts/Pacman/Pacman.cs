using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pacman : MonoBehaviour
{
    // Used to check for stuck condition
    Vector3 lastPosition;
  
    // Event triggered whenever this pacman collides with the player
    PacmanDeathEvent pacmanDeath = new PacmanDeathEvent();

    private void Start()
    {
        lastPosition = transform.position;
        Reset();
    }

    private void Reset()
    {
        StartCoroutine(CheckStuck());
    }

    IEnumerator CheckStuck()
    {
        yield return new WaitForSeconds(.5f);
        if (lastPosition == transform.position)
        {
            pacmanDeath.Invoke(gameObject, 0);
        }
        lastPosition = transform.position;
        Reset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we've been hit by one of the player's projectiles, then let your subscribers know
        if (collision.tag == "playerProjectile")
        {
            pacmanDeath.Invoke(gameObject, 100);
        }

        // If we've collided with the player
        else if (collision.tag == "Player")
        {
            pacmanDeath.Invoke(gameObject, 25);
        }

        else return;
    }

    public void AddPacmanDeathListener(UnityAction<GameObject, int> handler)
    {
        pacmanDeath.AddListener(handler);
    }
}
