using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public static Ending instance { get; private set; }

    public string[] levels;
    public int currentLevel;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }

        currentLevel = 0;
    }

    public void EndLevel(bool loadNextLevel)
    {
        if (loadNextLevel == true)
        {
            if(currentLevel + 1 <= levels.Length)
            {
                SceneManager.LoadScene(levels[currentLevel + 1]);
                currentLevel++;
            }
            else
            {
                SceneManager.LoadScene(levels[0]);
                currentLevel = 0;
            }
        }
        else
        {
            SceneManager.LoadScene(levels[0]);
            currentLevel = 0;
        }
    }
}

