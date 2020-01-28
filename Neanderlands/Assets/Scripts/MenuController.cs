using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Button startButton;
    public Button quitButton;
    public Text loadText;
    public bool paused;

    void Start()
    {
        loadText.text = "";
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        startButton.onClick.AddListener(delegate { StartGame(); });
    }

    void StartGame()
    {
        loadText.text = "Loading . . .";
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("Test");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
