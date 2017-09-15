using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartOneVOne()
    {
        PlayerPrefs.SetInt("Game", 0);
    }

    public void StartOneVAI()
    {
        PlayerPrefs.SetInt("Game", 1);
    }

    public void StartAIVAI()
    {
        PlayerPrefs.SetInt("Game", 2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene");
    }
}
