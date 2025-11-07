using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Scroll Settings")]
    public float scrollSpeed = 5f;       // How fast the camera moves
    
    [Header("Vertical Limits")]
    public float minY = -10f;            // Lowest camera position
    public float maxY = 10f;             // Highest camera position (optional)

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // Get scroll input (positive = scroll up, negative = scroll down)
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            // Move camera vertically based on scroll direction and speed
            pos.y += scrollInput * scrollSpeed;
        }

        // Clamp the camera position to limits
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
