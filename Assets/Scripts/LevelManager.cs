using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject levelFinishedCanvas;

    float timeScaleStarting = 1f;

    // Start is called before the first frame update
    void Start()
    {
        levelFinishedCanvas.SetActive(false);
        Time.timeScale = timeScaleStarting;
    }

    public void StarHitted()
    {
        Time.timeScale = 0f;
        levelFinishedCanvas.SetActive(true);
    }
}
