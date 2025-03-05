using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f;  // Speed of the car

    void Update()
    {
        // Move the car forward on the Z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
