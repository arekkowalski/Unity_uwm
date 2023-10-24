using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Pobierz warto�� wej�cia poziomego (A i D, strza�ki w lewo i w prawo)
        float verticalInput = Input.GetAxis("Vertical"); // Pobierz warto�� wej�cia pionowego (W i S, strza�ki w g�r� i w d�)

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime; // Tworzy wektor ruchu

        transform.Translate(movement); // Przesu� obiekt na podstawie wektora ruchu
    }
}
