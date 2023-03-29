using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizePortalScript : MonoBehaviour
{
    private bool pieni = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("kokoportaali"))
        {
            UnityEngine.Debug.Log("kokoportaali toimii");
            if (pieni == true)
            {
                transform.localScale = new Vector3(2, 2, 1);
                pieni= false;
            }
            else if (pieni == false) {
                transform.localScale = new Vector3(1, 1, 1);
                pieni= true;
            }

        }
    }
}
