using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float moveSpeed = 5f;
    public float lookSensitivity = 2f;
    public float jumpForce = 5f;
    public CharacterController controller;
    public Transform cameraTransform;

    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGrounded;

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();
        LookAround();
    }

    void MovePlayer()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // keep grounded

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        Vector3 camRotation = cameraTransform.localEulerAngles;
        camRotation.x -= mouseY;
        if (camRotation.x > 180) camRotation.x -= 360; // prevent flipping
        camRotation.x = Mathf.Clamp(camRotation.x, -80f, 80f);
        cameraTransform.localEulerAngles = new Vector3(camRotation.x, 0f, 0f);
    }
}
