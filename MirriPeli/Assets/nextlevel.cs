using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    Scene Level1, Level2, Level3, Level4, Level5;
    private void Start()
    {
        Level1 = SceneManager.GetSceneByName("Level 1");
        Level2 = SceneManager.GetSceneByName("Level 2");
        Level3 = SceneManager.GetSceneByName("Level 3");
        Level4 = SceneManager.GetSceneByName("Level 4");
        Level5 = SceneManager.GetSceneByName("Level 5");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene() == Level1)
        {
            SceneManager.LoadScene("Level 2");
        }
        if (SceneManager.GetActiveScene() == Level2)
        {
            SceneManager.LoadScene("Level 3");
        }
        if (SceneManager.GetActiveScene() == Level3)
        {
            SceneManager.LoadScene("Level 4");
        }
        if (SceneManager.GetActiveScene() == Level4)
        {
            SceneManager.LoadScene("Level 5");
        }
        if (SceneManager.GetActiveScene() == Level5)
        {
            SceneManager.LoadScene("Level 6");
        }
    }
}
