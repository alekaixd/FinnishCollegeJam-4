using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeverScript : MonoBehaviour
{
    public GameObject activateObject;
    [SerializeField]private bool hasContact;
    public TextMeshProUGUI infoText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasContact = true;
        infoText.text = "Press E to activate!";
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        hasContact = false;
        infoText.text = "";
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
