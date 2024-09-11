using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Массив префабов для спавна
    public Transform[] spawnPoints; // Точки спавна
    public float minSpawnInterval = 1f; // Минимальный интервал между спавнами
    public float maxSpawnInterval = 5f; // Максимальный интервал между спавнами
    public float destroyDistance = 10f; // Расстояние для удаления объекта ниже игрока
    public float spawnHeightThreshold = 0f; // Высота, после пересечения которой начнётся спавн

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Объект с тегом 'Player' не найден на сцене.");
        }

        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            // Проверяем, пересёк ли игрок заданную высоту
            if (player != null && player.transform.position.y >= spawnHeightThreshold)
            {
                // Ждём случайное количество времени между minSpawnInterval и maxSpawnInterval
                float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(waitTime);

                // Выбираем случайную точку спавна
                int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[randomSpawnIndex];

                // Выбираем случайный префаб для спавна
                int randomPrefabIndex = Random.Range(0, prefabsToSpawn.Length);
                GameObject prefabToSpawn = prefabsToSpawn[randomPrefabIndex];

                // Спавним выбранный префаб
                GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

                // Запускаем корутину для отслеживания объекта и его удаления
                StartCoroutine(CheckAndDestroyPrefab(spawnedObject));
            }

            // Ждём один кадр перед следующей проверкой
            yield return null;
        }
    }

    IEnumerator CheckAndDestroyPrefab(GameObject spawnedObject)
    {
        while (spawnedObject != null)
        {
            if (player != null && spawnedObject.transform.position.y < player.transform.position.y - destroyDistance)
            {
                // Удаляем объект, если он находится ниже определённого расстояния от игрока
                Destroy(spawnedObject);
            }

            // Ждём следующий кадр перед проверкой
            yield return null;
        }
    }
}
