using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void QuitButton()
    {
        SceneManager.LoadScene("StartMenu");   
    }
}
