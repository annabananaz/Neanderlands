using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenuCanvas;

    protected bool paused;


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Cursor.visible = false;
        Time.timeScale = 1f;            // Starts game at timescale 1 for active
        pauseMenuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Pause Game
    public void PauseGame()
    {
        Debug.Log("pausing ...");
        paused = true;
        Cursor.visible = true;
        pauseMenuCanvas.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    //Resume Game from paused
    public void ResumeGame()
    {
        Debug.Log("resuming game ...");
        paused = false;
        Cursor.visible = false;
        pauseMenuCanvas.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        //gc.PauseMusic();
        //crossHair.SetActive(false);
        //pauseMenuCanvas.SetActive(true);
        //Cursor.visible = true;
        //Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool gamePaused()
    {
        return paused;
    }
}
