using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;


public class PlayerTeleportation : MonoBehaviour
{
    private GameObject currentTeleporter;
    public TextMeshProUGUI infoText;

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {

            UnityEngine.Debug.Log("E painaminen toimii");

            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                UnityEngine.Debug.Log("Toimii 2");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.Debug.Log("Toimi3");
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            infoText.text = "Press E to teleport!";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                infoText.text = "";
            }
        }
    }
}
