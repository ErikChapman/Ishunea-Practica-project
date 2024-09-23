using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    // ������ �������� �������� (��������, ������� ��������, ������)
    public GameObject[] bonusPrefabs;

    // ������ ����� ������ �������
    public Transform[] spawnPoints;

    // �������� ����� �������� �������
    public float spawnInterval = 10f;

    // ����� �������� ����� ������� ������
    public float startDelay = 5f;

    void Start()
    {
        // �������� ����� ������� � �������� ��������� � ����������
        InvokeRepeating("SpawnBonus", startDelay, spawnInterval);
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
        Instantiate(bonusPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
