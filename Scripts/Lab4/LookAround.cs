using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround_ : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 200f;
    public float minVerticalRotation = -90f; // Minimalny k¹t obrotu w pionie
    public float maxVerticalRotation = 90f;  // Maksymalny k¹t obrotu w pionie

    private float verticalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Ograniczenie obracania kamery w pionie
        verticalRotation -= mouseYMove;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

        // Obracanie kamery wokó³ osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // Obracanie kamery w pionie
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
