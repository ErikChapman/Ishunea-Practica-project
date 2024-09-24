using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Массив префабов для спавна
    public Transform[] spawnPoints; // Точки спавна
    public float minSpawnInterval = 1f; // Минимальный интервал между спавнами
    public float maxSpawnInterval = 5f; // Максимальный интервал между спавнами
    public float destroyDistance = 10f; // Расстояние для удаления объекта ниже игрока
    public float spawnHeightThreshold = 0f; // Высота, после пересечения которой начнётся спавн

    public float minHeight = 0f;  // Минимальная высота
    public float maxHeight = 100f; // Максимальная высота

    public Canvas gameOverCanvas; // Канвас для отображения при завершении игры
    public Image hpBar; // Полоска здоровья
    public float maxHP = 100f; // Максимальное здоровье
    public float currentHP; // Текущее здоровье

    private GameObject player;
    private int destroyedObjectCount = 0; // Счётчик удалённых объектов

    private void Start()
    {
        currentHP = maxHP; // Устанавливаем текущее здоровье на максимум в начале игры

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Объект с тегом 'Player' не найден на сцене.");
        }

        // Убедитесь, что канвас завершения игры изначально скрыт
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
            // Проверяем, пересёк ли игрок заданную высоту
            if (player != null && player.transform.position.y >= spawnHeightThreshold)
            {
                // Вычисляем относительную высоту игрока между minHeight и maxHeight
                float playerHeight = Mathf.Clamp(player.transform.position.y, minHeight, maxHeight);
                float heightFactor = (playerHeight - minHeight) / (maxHeight - minHeight);

                // Вычисляем время спавна в зависимости от высоты
                float waitTime = Mathf.Lerp(maxSpawnInterval, minSpawnInterval, heightFactor);
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
                destroyedObjectCount++; // Увеличиваем счётчик удалённых объектов

                // Уменьшаем здоровье
                currentHP -= 33; // Например, вычитаем 10 единиц здоровья за каждый удалённый объект
                hpBar.fillAmount = currentHP / maxHP; // Обновляем заполнение полоски здоровья

                // Проверяем, если здоровье закончилось, завершаем игру
                if (currentHP <= 0)
                {
                    // Останавливаем игру и отображаем канвас завершения игры
                    if (gameOverCanvas != null)
                    {
                        gameOverCanvas.gameObject.SetActive(true);
                        Time.timeScale = 0f;
                    }
                }
                // Если объект был удалён 3 раза, также завершаем игру
                //if (destroyedObjectCount >= 3)
                //{
                //    if (gameOverCanvas != null)
                //    {
                //        gameOverCanvas.gameObject.SetActive(true);
                //        Time.timeScale = 0f;
                //    }
                //}
            }

            // Ждём следующий кадр перед проверкой
            yield return null;
        }
    }
}
