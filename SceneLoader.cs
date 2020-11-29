using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameState state;
    public void LoadScene()
    {

        int CurrenScenetIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrenScenetIndex + 1);
    }


    public void GameQuit()
    {

        Application.Quit();
    }
    public void Restart()
    {

        int CurrenScenetIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        FindObjectOfType<GameState>().Yoket();
    }

}
