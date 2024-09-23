using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    // Массив бонусных префабов (например, быстрая стрельба, лазеры)
    public GameObject[] bonusPrefabs;

    // Массив точек спавна бонусов
    public Transform[] spawnPoints;

    // Интервал между спавнами бонусов
    public float spawnInterval = 10f;

    // Время задержки перед началом спавна
    public float startDelay = 5f;

    void Start()
    {
        // Начинаем спавн бонусов с заданной задержкой и интервалом
        InvokeRepeating("SpawnBonus", startDelay, spawnInterval);
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
        Instantiate(bonusPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
