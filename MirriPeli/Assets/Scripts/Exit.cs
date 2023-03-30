using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Button button;
    public void GetOut()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
