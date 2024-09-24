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

    // ������ �� ������
    public Transform player;

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
        GameObject spawnedBonus = Instantiate(bonusPrefab, spawnPoint.position, spawnPoint.rotation);

        // ��������� �������� ��� ��������, ����� ����� ���� ������
        StartCoroutine(CheckBonusPosition(spawnedBonus));
    }

    IEnumerator CheckBonusPosition(GameObject bonus)
    {
        // ���������, �� ���� �� ����� �� 10 ������ ���� ������
        while (bonus != null)
        {
            if (bonus.transform.position.y < player.position.y - 10f)
            {
                Destroy(bonus); // ������� �����
                yield break; // ������������� ��������
            }

            yield return null; // ���� ��������� ����
        }
    }
}
