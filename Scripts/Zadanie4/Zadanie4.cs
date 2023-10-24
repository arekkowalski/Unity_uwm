using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Pobierz wartoœæ wejœcia poziomego (A i D, strza³ki w lewo i w prawo)
        float verticalInput = Input.GetAxis("Vertical"); // Pobierz wartoœæ wejœcia pionowego (W i S, strza³ki w górê i w dó³)

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime; // Tworzy wektor ruchu

        transform.Translate(movement); // Przesuñ obiekt na podstawie wektora ruchu
    }
}
