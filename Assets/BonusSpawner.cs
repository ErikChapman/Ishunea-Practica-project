using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    // ������ �������� �������� (��������, ������� ��������, ������)
    public GameObject[] bonusPrefabs;



    // �������� ����� �������� �������
    public float spawnInterval = 10f;

    // ������, � ������� ���������� ����� �������
    public float spawnStartHeight = 50f;

    // ������ ����� ������ �������
    public Transform[] spawnPoints;

    // ������ �� ������
    public Transform player;

    private bool canSpawnBonuses = false; // ���� ��� ��������, ����� �� �������� ������

    void Update()
    {
        // ���� ������ ������ ��������� ������ ������ ��� ������ ������
        if (player.position.y >= spawnStartHeight && !canSpawnBonuses)
        {
            canSpawnBonuses = true;
            StartSpawning(); // �������� �������� ������
        }
    }

    void SpawnBonus()
    {
        // ���������, ���� �� �����-����� � �������� �������
        if (spawnPoints.Length == 0 || bonusPrefabs.Length == 0)
        {
            Debug.LogWarning("�� ������� �����-����� ��� �������� �������!");
            return;
        }

        // �������� ��������� ����� ������ �� �������
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // �������� ��������� ������ ������
        GameObject bonusPrefab = bonusPrefabs[Random.Range(0, bonusPrefabs.Length)];

        // ������� ����� �� ��������� �����
        GameObject spawnedBonus = Instantiate(bonusPrefab, spawnPoint.position, spawnPoint.rotation);

        // ��������� �������� ��� ��������, ����� ����� ���� ������
        StartCoroutine(CheckBonusPosition(spawnedBonus));
    }

    void StartSpawning()
    {
        // �������� ����� ������� � �������� ����������
        InvokeRepeating("SpawnBonus", 0f, spawnInterval);
    }

    

    IEnumerator CheckBonusPosition(GameObject bonus)
    {
        float timeBelowPlayer = 0f; // �����, ������� ����� ��������� ���� ������

        // ���������, �� ���� �� ����� �� 10 ������ ���� ������
        while (bonus != null)
        {
            if (bonus.transform.position.y < player.position.y - 10f)
            {
                timeBelowPlayer += Time.deltaTime; // ����������� ������ �� ����� ���������� �����

                if (timeBelowPlayer >= 8f) // ���� ����� ��������� ���� ������ ����� 8 ������
                {
                    Destroy(bonus); // ������� �����
                    yield break; // ������������� ��������
                }
            }
            else
            {
                timeBelowPlayer = 0f; // ���������� ������, ���� ����� �������� ���� 10 ������ ���� ������
            }

            yield return null; // ���� ��������� ����
        }
    }
}
