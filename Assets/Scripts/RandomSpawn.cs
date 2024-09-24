using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI ����������

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // ������ �������� ��� ������
    public Transform[] spawnPoints; // ����� ������
    public float minSpawnInterval = 1f; // ����������� �������� ����� ��������
    public float maxSpawnInterval = 5f; // ������������ �������� ����� ��������
    public float destroyDistance = 10f; // ���������� ��� �������� ������� ���� ������
    public float spawnHeightThreshold = 0f; // ������, ����� ����������� ������� ������� �����

    public float minHeight = 0f;  // ����������� ������
    public float maxHeight = 100f; // ������������ ������

    public Canvas gameOverCanvas; // ������ ��� ����������� ��� ���������� ����
    public Image hpBar; // ������� ��������
    public float maxHP = 100f; // ������������ ��������
    public float currentHP; // ������� ��������

    private GameObject player;
    private int destroyedObjectCount = 0; // ������� �������� ��������

    private void Start()
    {
        currentHP = maxHP; // ������������� ������� �������� �� �������� � ������ ����

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("������ � ����� 'Player' �� ������ �� �����.");
        }

        // ���������, ��� ������ ���������� ���� ���������� �����
        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(false);
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
                // ��������� ������������� ������ ������ ����� minHeight � maxHeight
                float playerHeight = Mathf.Clamp(player.transform.position.y, minHeight, maxHeight);
                float heightFactor = (playerHeight - minHeight) / (maxHeight - minHeight);

                // ��������� ����� ������ � ����������� �� ������
                float waitTime = Mathf.Lerp(maxSpawnInterval, minSpawnInterval, heightFactor);
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
                destroyedObjectCount++; // ����������� ������� �������� ��������

                // ��������� ��������
                currentHP -= 33; // ��������, �������� 10 ������ �������� �� ������ �������� ������
                hpBar.fillAmount = currentHP / maxHP; // ��������� ���������� ������� ��������

                // ���������, ���� �������� �����������, ��������� ����
                if (currentHP <= 0)
                {
                    // ������������� ���� � ���������� ������ ���������� ����
                    if (gameOverCanvas != null)
                    {
                        gameOverCanvas.gameObject.SetActive(true);
                        Time.timeScale = 0f;
                    }
                }
                // ���� ������ ��� ����� 3 ����, ����� ��������� ����
                //if (destroyedObjectCount >= 3)
                //{
                //    if (gameOverCanvas != null)
                //    {
                //        gameOverCanvas.gameObject.SetActive(true);
                //        Time.timeScale = 0f;
                //    }
                //}
            }

            // ��� ��������� ���� ����� ���������
            yield return null;
        }
    }
}
