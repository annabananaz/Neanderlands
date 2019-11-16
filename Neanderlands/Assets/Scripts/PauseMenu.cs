using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameController gc;
    
    public GameObject resumeButton;
    public GameObject quitButton;

    // Start is called before the first frame update
    void Awake()
    {
        gc = GameObject.FindObjectOfType<GameController>();
        
        resumeButton.GetComponent<Button>().onClick.AddListener(delegate { gc.ResumeGame(); });
        //quitButton.GetComponent<Button>().onClick.AddListener(delegate { gc.QuitGame(); });
    }
}
