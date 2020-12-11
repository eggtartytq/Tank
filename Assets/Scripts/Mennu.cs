using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Mennu : MonoBehaviour
{
    

    public void PlayGame()
    {
        SceneManager.LoadScene("gameMap");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
