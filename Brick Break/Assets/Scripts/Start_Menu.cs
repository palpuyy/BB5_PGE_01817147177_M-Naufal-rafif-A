using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game Pushed");
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("BrickBreak");
    }
}
