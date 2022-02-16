using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject RestartButton;

    public bool isGameActive;

    public GameObject StartButton;

    private void Awake()
    {
        Instance = this;

        isGameActive = false;

        Time.timeScale = 0;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void startGame()
    {
        isGameActive = true;

        Time.timeScale = 1;

        StartButton.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}
