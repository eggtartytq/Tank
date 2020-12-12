using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishOP : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("gameMap");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
