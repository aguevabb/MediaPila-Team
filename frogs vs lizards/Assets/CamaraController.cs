using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 15f;
    public Camera mainCamera;
    private bool buttonReleased;

    private void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);

        if (Input.GetMouseButton(1))
        {
            buttonReleased = false;
            if (mainCamera.fieldOfView >= 45)
            {
                mainCamera.fieldOfView -= 1;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            buttonReleased = true;
        }

        if (buttonReleased)
        {
            if (mainCamera.fieldOfView <= 80)
            {
                mainCamera.fieldOfView += 1;
            }
        }
    }
}
