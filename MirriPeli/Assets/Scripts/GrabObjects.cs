using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;

    public GameObject grabbedObject;
    private int layerIndex;
    private Vector2 originalSize;
    private Vector2 originalOffset;
    private BoxCollider2D collider2D;
    Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Grab");
        collider2D = transform.Find("Ray").GetComponent<BoxCollider2D>();
        originalOffset = collider2D.offset;
        originalSize = collider2D.size;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Vector2 direction in directions)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, direction, rayDistance, ~LayerMask.NameToLayer("Default"));
            if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
            {
                if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
                {
                    Debug.Log("key down");
                    grabbedObject = hitInfo.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    grabbedObject.transform.position = grabPoint.position;
                    grabbedObject.transform.SetParent(transform);
                    grabbedObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                    grabbedObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    Vector2 colSize = grabbedObject.GetComponent<BoxCollider2D>().size;
                    Vector2 newSize = new Vector2(Mathf.Max(colSize.x, originalSize.x) + Mathf.Min(colSize.x, originalSize.x), Mathf.Max(colSize.y, originalSize.y));
                    Vector2 newOffset = new Vector2(newSize.y / 2, 0);
                    collider2D.size = newSize;
                    collider2D.offset += newOffset;
                }
                else if (Input.GetKey(KeyCode.Space) != true && grabbedObject != null) // kun palikan laittaa napin p‰‰lle se ei irtoa otteesta
                {
                    Debug.Log("key up");
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbedObject.transform.SetParent(null);
                    grabbedObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    grabbedObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    grabbedObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    grabbedObject = null;
                    collider2D.size = originalSize;
                    collider2D.offset = originalOffset;
                }
            }

            Debug.DrawRay(rayPoint.position, direction * rayDistance);
        }

        
    }
}
