using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Mennu : MonoBehaviour
{
    public int nextScene;

    public void PlayGame()
    {
        SceneManager.LoadScene("gameMap");
    }



    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
