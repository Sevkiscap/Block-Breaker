using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [Range(0.5f,5f) ][SerializeField] float zaman;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text score;

    private void Awake()
    {
        int gameAmount = FindObjectsOfType<GameState>().Length;
        if (gameAmount > 1)
        {
            DestroyImmediate(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {      
        score.text = ("Score = ") + playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = zaman;

    }
    public void Point()
    {
        playerScore = playerScore + pointsPerBlock;
        score.text = ("Score = ") + playerScore.ToString();

    }

    public void Yoket()
    {
        Destroy(gameObject);
    }
}

