using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    // Массив бонусных префабов (например, быстрая стрельба, лазеры)
    public GameObject[] bonusPrefabs;



    // Интервал между спавнами бонусов
    public float spawnInterval = 10f;

    // Высота, с которой начинается спавн бонусов
    public float spawnStartHeight = 50f;

    // Массив точек спавна бонусов
    public Transform[] spawnPoints;

    // Ссылка на игрока
    public Transform player;

    private bool canSpawnBonuses = false; // Флаг для проверки, можно ли спавнить бонусы

    void Update()
    {
        // Если высота игрока превышает нужную высоту для начала спавна
        if (player.position.y >= spawnStartHeight && !canSpawnBonuses)
        {
            canSpawnBonuses = true;
            StartSpawning(); // Начинаем спавнить бонусы
        }
    }

    void SpawnBonus()
    {
        // Проверяем, есть ли спавн-точки и бонусные префабы
        if (spawnPoints.Length == 0 || bonusPrefabs.Length == 0)
        {
            Debug.LogWarning("Не указаны спавн-точки или бонусные префабы!");
            return;
        }

        // Выбираем случайную точку спавна из массива
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Выбираем случайный префаб бонуса
        GameObject bonusPrefab = bonusPrefabs[Random.Range(0, bonusPrefabs.Length)];

        // Спавним бонус на выбранной точке
        GameObject spawnedBonus = Instantiate(bonusPrefab, spawnPoint.position, spawnPoint.rotation);

        // Запускаем корутину для проверки, когда бонус ниже игрока
        StartCoroutine(CheckBonusPosition(spawnedBonus));
    }

    void StartSpawning()
    {
        // Начинаем спавн бонусов с заданным интервалом
        InvokeRepeating("SpawnBonus", 0f, spawnInterval);
    }

    

    IEnumerator CheckBonusPosition(GameObject bonus)
    {
        float timeBelowPlayer = 0f; // Время, которое бонус находится ниже игрока

        // Проверяем, не упал ли бонус на 10 единиц ниже игрока
        while (bonus != null)
        {
            if (bonus.transform.position.y < player.position.y - 10f)
            {
                timeBelowPlayer += Time.deltaTime; // Увеличиваем таймер на время прошедшего кадра

                if (timeBelowPlayer >= 8f) // Если бонус находится ниже игрока более 8 секунд
                {
                    Destroy(bonus); // Удаляем бонус
                    yield break; // Останавливаем корутину
                }
            }
            else
            {
                timeBelowPlayer = 0f; // Сбрасываем таймер, если бонус поднялся выше 10 единиц ниже игрока
            }

            yield return null; // Ждем следующий кадр
        }
    }
}
