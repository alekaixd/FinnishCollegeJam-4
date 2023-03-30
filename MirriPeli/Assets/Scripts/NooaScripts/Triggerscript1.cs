using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerscript1 : MonoBehaviour
{
    [SerializeField] private AudioSource l1x2;
    [SerializeField] private AudioSource l1x3;
    [SerializeField] private AudioSource l1x4;
    [SerializeField] private AudioSource l1x5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger2"))
        {
            l1x2.Play();
        }
        if (collision.CompareTag("Trigger3"))
        {
            l1x3.Play();
        }
        if (collision.CompareTag("Trigger4"))
        {
            l1x4.Play();
        }
        if (collision.CompareTag("Trigger4"))
        {
            l1x4.Play();
        }
        if (collision.CompareTag("Trigger5"))
        {
            l1x5.Play();
        }

    }
}
