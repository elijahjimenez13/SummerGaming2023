using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    bool paused = false;

    public GameObject pauseScreen;

    void Awake()
    {
        pauseScreen.SetActive(false);
    }
    
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                ResumeGame();
            } else
            {
            PauseGame();
            }
        }
    }

    void PauseGame()
    {
        paused = true;
        pauseScreen.SetActive(paused);
        Time.timeScale = 0f;

        FindObjectOfType<PlayerController>().DisableUI();
    }

    public void ResumeGame()
    {
        paused = false;
        pauseScreen.SetActive(paused);
        Time.timeScale = 1f;

        FindObjectOfType<PlayerController>().EnableUI();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
