using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float mousesense = 150f;
    public Transform cameraAxis;
    public Transform character;
    float xRotation = 0f;
    float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesense * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50, 10);

        yRotation += mouseX;

        cameraAxis.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        character.Rotate(Vector3.up * mouseX);
    }

}
