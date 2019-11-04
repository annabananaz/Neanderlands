using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Pause Game
    public void PauseGame()
    {
        Cursor.visible = true;
        Debug.Log("pausing ...");
    }

    //Resume Game from paused
    public void ResumeGame()
    {
        Cursor.visible = false;
        Debug.Log("resuming game ...");
    }
}
