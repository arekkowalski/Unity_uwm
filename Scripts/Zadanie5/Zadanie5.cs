using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Prefabrykat obiektu typu Cube
    public int numberOfCubes = 10; // Liczba obiektów do wygenerowania
    public float spawnAreaWidth = 10.0f; // Szerokoœæ obszaru, na którym generujemy obiekty
    public float spawnAreaLength = 10.0f; // D³ugoœæ obszaru, na którym generujemy obiekty

    private List<Vector3> spawnPositions = new List<Vector3>();

    void Start()
    {
        GenerateSpawnPositions();
        SpawnCubes();
    }

    void GenerateSpawnPositions()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            spawnPositions.Add(spawnPosition);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition;
        bool validPosition = false;

        do
        {
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            float randomZ = Random.Range(-spawnAreaLength / 2, spawnAreaLength / 2);
            randomPosition = new Vector3(randomX, 0, randomZ);

            validPosition = IsPositionValid(randomPosition);
        } while (!validPosition);

        return randomPosition;
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 existingPosition in spawnPositions)
        {
            if (Vector3.Distance(position, existingPosition) < 1.0f) // Minimalna odleg³oœæ miêdzy obiektami (1.0f)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnCubes()
    {
        foreach (Vector3 position in spawnPositions)
        {
            Instantiate(cubePrefab, position, Quaternion.identity);
        }
    }
}
