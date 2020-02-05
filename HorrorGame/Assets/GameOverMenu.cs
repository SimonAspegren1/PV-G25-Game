﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("NewGame");
    }

    public void QuitGame()
    {
        Time.timeScale = 0f;
        Application.Quit();
    }

}