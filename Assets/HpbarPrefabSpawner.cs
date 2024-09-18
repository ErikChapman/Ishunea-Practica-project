using UnityEngine;

public class HpbarPrefabSpawner : MonoBehaviour
{
    // ������ ��������, ������� ����� ����������
    public GameObject[] asteroidPrefabs;

    // ������ ����� ������
    public Transform[] spawnPoints;

    // ������ �� ������, ������� ������� ������� ���������
    public GameOverOnAsteroidBelow asteroidCounter;

    // ������� ���������� ������� ����������
    private int currentFallenAsteroids = 0;

    void Update()
    {
        // ���������, ���������� �� ���������� ������� ����������
        //if (asteroidCounter.fallenAsteroids != currentFallenAsteroids)
        {
            //currentFallenAsteroids = asteroidCounter.fallenAsteroids;

            // ���������, ����� �������� �� ��������� ���������� ��������� ��������
            if (currentFallenAsteroids > 0 && currentFallenAsteroids <= asteroidPrefabs.Length)
            {
                // ������� ��������������� ������
                SpawnAsteroidPrefab(currentFallenAsteroids - 1); // -1 ��� ����������� ������� �������
            }
        }
    }

    void SpawnAsteroidPrefab(int prefabIndex)
    {
        // �������� ��������� ����� ������
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ������� ��������� ������
        Instantiate(asteroidPrefabs[prefabIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
