using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenuCanvas;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;            // Starts game at timescale 1 for active
        pauseMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Pause Game
    public void PauseGame()
    {
        Debug.Log("pausing ...");
        Cursor.visible = true;
        pauseMenuCanvas.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
    }

    //Resume Game from paused
    public void ResumeGame()
    {
        Debug.Log("resuming game ...");
        Cursor.visible = false;
        pauseMenuCanvas.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;


        //gc.PauseMusic();
        //crossHair.SetActive(false);
        //pauseMenuCanvas.SetActive(true);
        //Cursor.visible = true;
        //Time.timeScale = 0;
    }
}
