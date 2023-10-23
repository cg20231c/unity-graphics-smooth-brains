using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour{
    public float sensitivity = 2.0f;
    public Transform player;
    private float rotationX = 0;
    [SerializeField] private Transform playerCam;

    void Start(){
        // Lock and hide the cursor.
        player = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player (Y rotation) input.
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        player.Rotate(Vector3.up * mouseX);
    
        // Camera (Z rotation) input.
        float mouseY = -Input.GetAxis("Mouse Y") * sensitivity;
        rotationX += mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);  // Limit the camera's rotation to avoid flipping.
        playerCam.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
