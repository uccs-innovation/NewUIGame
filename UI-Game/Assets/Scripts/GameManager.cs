using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static UnityEvent gamePausedEvent = new UnityEvent();


    // is the game currently paused?
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Player pauses game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePausedEvent.Invoke();
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                isPaused = false;
                Cursor.visible = false;
            }

        }
    }

    public static void AddGamePausedEventListener(UnityAction handler)
    {
        gamePausedEvent.AddListener(handler);
    }
}
