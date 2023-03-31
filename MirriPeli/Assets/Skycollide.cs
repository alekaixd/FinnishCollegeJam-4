using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skycollide : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<MovementScript>().IsGonnaDie = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<MovementScript>().IsGonnaDie = false;
    }*/
}
