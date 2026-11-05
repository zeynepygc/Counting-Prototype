using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float minX = 20f;
    public float maxX = 36f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}