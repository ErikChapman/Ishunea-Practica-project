using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // ������ �������� ��� ������
    public Transform[] spawnPoints; // ����� ������
    public float minSpawnInterval = 1f; // ����������� �������� ����� ��������
    public float maxSpawnInterval = 5f; // ������������ �������� ����� ��������
    public float destroyDistance = 10f; // ���������� ��� �������� ������� ���� ������
    public float spawnHeightThreshold = 0f; // ������, ����� ����������� ������� ������� �����

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("������ � ����� 'Player' �� ������ �� �����.");
        }

        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            // ���������, ������ �� ����� �������� ������
            if (player != null && player.transform.position.y >= spawnHeightThreshold)
            {
                // ��� ��������� ���������� ������� ����� minSpawnInterval � maxSpawnInterval
                float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(waitTime);

                // �������� ��������� ����� ������
                int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[randomSpawnIndex];

                // �������� ��������� ������ ��� ������
                int randomPrefabIndex = Random.Range(0, prefabsToSpawn.Length);
                GameObject prefabToSpawn = prefabsToSpawn[randomPrefabIndex];

                // ������� ��������� ������
                GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

                // ��������� �������� ��� ������������ ������� � ��� ��������
                StartCoroutine(CheckAndDestroyPrefab(spawnedObject));
            }

            // ��� ���� ���� ����� ��������� ���������
            yield return null;
        }
    }

    IEnumerator CheckAndDestroyPrefab(GameObject spawnedObject)
    {
        while (spawnedObject != null)
        {
            if (player != null && spawnedObject.transform.position.y < player.transform.position.y - destroyDistance)
            {
                // ������� ������, ���� �� ��������� ���� ������������ ���������� �� ������
                Destroy(spawnedObject);
            }

            // ��� ��������� ���� ����� ���������
            yield return null;
        }
    }
}
