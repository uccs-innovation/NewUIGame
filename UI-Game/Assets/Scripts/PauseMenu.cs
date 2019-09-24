using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;

    [SerializeField]
    GameObject instructionsPrefab;

    GameObject instructions;

    // Instantiation of black background object
    Canvas pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Add this script's delegate as a listener for the game paused event
        GameManager.AddGamePausedEventListener(Pause);

        // Get a reference to the canvas with buttons attached to this gameobject
        pauseCanvas = GetComponentInChildren<Canvas>();

        // Create a fade canvas
        pauseCanvas.enabled = false;
    }

    // Delegate for the game paused event
    void Pause()
    {
        if (isPaused)
        {
            Cursor.visible = false;
            pauseCanvas.enabled = false;
            isPaused = false;
            
        }
        else
        {
            Cursor.visible = true;
            pauseCanvas.enabled = true;
            isPaused = true;
        }
    }

    public void HandleQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }

    public void HandleControls()
    {
        pauseCanvas.enabled = false;
        instructions = Instantiate(instructionsPrefab);
        instructions.GetComponent<InstructionsScreen>().AddHandler(ReturnHandler);
    }

    void ReturnHandler()
    {
        if (instructions != null)
        {
            Destroy(instructions);
            pauseCanvas.enabled = true;
        }
    }

}
