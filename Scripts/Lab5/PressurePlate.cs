using UnityEngine;

public class UpwardPlatform : MonoBehaviour
{
    public float upwardForce = 2f;
    public float upwardDuration = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(UpwardEffect(other.transform));
        }
    }

    private System.Collections.IEnumerator UpwardEffect(Transform playerTransform)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = playerTransform.position;

        while (elapsedTime < upwardDuration)
        {
            float yOffset = upwardForce * Time.deltaTime;
            playerTransform.Translate(Vector3.up * yOffset);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Opcjonalnie mo¿esz dodaæ dodatkowe czynnoœci po zakoñczeniu efektu
    }
}
