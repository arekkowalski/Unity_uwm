using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    public float returnSpeed = 1f;  // Prêdkoœæ powrotu do pocz¹tkowej pozycji
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    private float downPosition;
    private float upPosition;
    private Vector3 initialPosition;

    void Start()
    {
        upPosition = transform.position.y + distance;
        downPosition = transform.position.y;
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isRunningUp && transform.position.y >= upPosition)
        {
            isRunning = false;
            StartCoroutine(ReturnToInitialPosition());
        }
        else if (isRunningDown && transform.position.y <= downPosition)
        {
            isRunning = false;
            StartCoroutine(ReturnToInitialPosition());
        }

        if (isRunning)
        {
            Vector3 move = transform.up * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    IEnumerator ReturnToInitialPosition()
    {
        float elapsedTime = 0f;
        Vector3 currentPosition = transform.position;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(currentPosition, initialPosition, elapsedTime);
            elapsedTime += Time.deltaTime * returnSpeed;
            yield return null;
        }

        // Ustawienie dok³adnej pozycji na koniec interpolacji
        transform.position = initialPosition;
        elevatorSpeed = Mathf.Abs(elevatorSpeed); // Resetowanie prêdkoœci
        isRunningUp = true;
        isRunningDown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");

            if (transform.position.y >= upPosition)
            {
                isRunningDown = true;
                isRunningUp = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.y <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
        }
    }
}
