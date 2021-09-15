using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject buttonStart;
    [SerializeField] private GameObject buttonRestart;
    [SerializeField] private GameObject[] runtimeObjects;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        buttonStart.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        buttonStart.SetActive(false);
        foreach (GameObject item in runtimeObjects)
        {
            item.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void GameOver()
    {
        Time.timeScale = 0f;
        buttonRestart.SetActive(true);
        foreach (GameObject item in runtimeObjects)
        {
            item.SetActive(false);
        }
    }
}
