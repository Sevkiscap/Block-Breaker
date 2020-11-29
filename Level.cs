using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //Serialized for debugging
    public void CountBreakableObjects()
    {
        breakableBlocks++;
    }

    public void CountBreakableObjects2()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
