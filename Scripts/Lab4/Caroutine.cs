using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{
    public int numberOfObjectsToGenerate = 10;
    public GameObject block;
    public float delay = 3.0f;
    public List<Material> materials; // Lista dostępnych materiałów

    void Start()
    {
        StartCoroutine(GenerateObjectsWithDelay());
    }

    IEnumerator GenerateObjectsWithDelay()
    {
        Debug.Log("Coroutine started");

        Vector3 platformPosition = transform.position;

        for (int i = 0; i < numberOfObjectsToGenerate; i++)
        {
            float randomX = Random.Range(platformPosition.x - 5, platformPosition.x + 5);
            float randomZ = Random.Range(platformPosition.z - 5, platformPosition.z + 5);
            Vector3 randomPosition = new Vector3(randomX, platformPosition.y, randomZ);
            GameObject newObject = Instantiate(block, randomPosition, Quaternion.identity);

            // Losowe przydzielanie materiału
            if (materials.Count > 0)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Count)];
                Renderer renderer = newObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = randomMaterial;
                }
            }

            yield return new WaitForSeconds(delay);
        }

        Debug.Log("Coroutine finished");
    }
}
