using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    int currentSceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameCompletedScene()
    {
        SceneManager.LoadScene("Game Completed");
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadThisLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
