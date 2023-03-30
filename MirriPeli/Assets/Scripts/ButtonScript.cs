using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject otherObject;
    private Sprite originalSprite;
    public Sprite pressedDownSprite;
    private int numberOfCollisions;
    private SpriteRenderer spriteRenderer;
    public bool activated = false;
    public GameObject otherButton;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == true && otherButton == null)
        {
            otherObject.SetActive(false);
        }
        else if (activated == true && otherButton.GetComponent<ButtonScript>().activated == true)
        {
            otherObject.SetActive(false);
        }
        else
        {
            otherObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        numberOfCollisions += 1;
        if (numberOfCollisions == 1)
        {
            activated = true;
            spriteRenderer.sprite = pressedDownSprite;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        numberOfCollisions -= 1;
        if (numberOfCollisions == 0)
        {
            activated = false;
            
            spriteRenderer.sprite = originalSprite;
        }
    }
}

