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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        numberOfCollisions += 1;
        if (numberOfCollisions == 1)
        {
            otherObject.SetActive(false);
            spriteRenderer.sprite = pressedDownSprite;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        numberOfCollisions -= 1;
        if (numberOfCollisions == 0)
        {
            otherObject.SetActive(true);
            spriteRenderer.sprite = originalSprite;
        }
    }
}

