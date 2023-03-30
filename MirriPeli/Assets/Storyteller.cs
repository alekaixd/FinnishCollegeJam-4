using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyteller : MonoBehaviour
{
    [SerializeField] AudioSource Story1, Story2, Story3, Story4, Story5, Story6, Story7, Story8;
    bool audioplayed;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        while (audioplayed)
        {
            var audioclipcount = 1;
            if (gameObject.name == audioclipcount.ToString())
            {
                Story1.
                audioplayed = true;
                break;
            }
        }
    }Hyvin paskaa koodia*/
}
