using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f;

    void Update()
    {
        Vector3 direction = player.position - transform.position;

        // snap rotation to direction
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // rotate around player
        transform.RotateAround(player.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}