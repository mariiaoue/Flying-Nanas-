using UnityEngine;

public class FollowCameraOnZ : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float offsetZ = 0f; // Optional offset to maintain a gap between the platform and the camera

    void Update()
    {
        if (cameraTransform != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = cameraTransform.position.z + offsetZ; // Match the camera's Z position with optional offset
            transform.position = newPosition;
        }
    }
}
