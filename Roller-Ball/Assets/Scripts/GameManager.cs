using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded;

    // Start is called before the first frame update
    void Start()
    {
        _gameHasEnded = false;
    }

    public void EndGame() // Called by the player when it dies
    {
        if (_gameHasEnded != true)
        {
            _gameHasEnded = true;
            Invoke("ResetLevel", 2f);
        }
    }

    private void ResetLevel()
    {
        // Resets scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
    }
}
