using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pacman : MonoBehaviour
{
    // Event triggered whenever this pacman collides with the player
    PacmanDeathEvent pacmanDeath = new PacmanDeathEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we've been hit by one of the player's projectiles, then update the player's score
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
