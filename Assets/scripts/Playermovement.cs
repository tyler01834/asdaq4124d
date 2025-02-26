using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float mouseSensitivity = 100.0f; // Mouse sensitivity for camera movement

    private Transform cameraTransform; // Reference to the camera transform
    private float rotationY = 0.0f;
    private float rotationX = 0.0f;

    void Start()
    {
        // Find the child camera transform
        cameraTransform = GetComponentInChildren<Camera>().transform;

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = transform.TransformDirection(movement); // Move relative to player's rotation
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Camera movement
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f);

        // Rotate the player object based on camera rotation
        transform.localEulerAngles = new Vector3(0.0f, rotationX, 0.0f);
        cameraTransform.localEulerAngles = new Vector3(rotationY, 0.0f, 0.0f);
    }
}
