using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementCamera : MonoBehaviour
{
    public Slider slider;
    float sensitivity;
    public Transform playerBody;


    float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f - SaveScript.camerRotationX, 90f - SaveScript.camerRotationX);

        transform.localRotation = Quaternion.Euler(xRotation + SaveScript.camerRotationX, 0f, 0);
        playerBody.Rotate(0, mouseX, 0);

        sensitivity = slider.value;
    }


}
