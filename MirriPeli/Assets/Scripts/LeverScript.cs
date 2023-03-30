using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject activateObject;
    private bool hasContact;

    private void OnTriggerStay2D(Collider2D collision)
    {
        hasContact = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        hasContact = false;
    }

    private void Update()
    {
        if(hasContact == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && activateObject.activeSelf)
            {
                Debug.Log("ressed E");
                activateObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("ressed E");
                activateObject.SetActive(true);
            }
        }
    }
}
