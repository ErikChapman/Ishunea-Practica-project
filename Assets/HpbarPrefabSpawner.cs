using UnityEngine;

public class HpbarPrefabSpawner : MonoBehaviour
{
    // Массив префабов, которые будут спавниться
    public GameObject[] asteroidPrefabs;

    // Массив точек спавна
    public Transform[] spawnPoints;

    // Ссылка на скрипт, который считает упавшие астероиды
    public GameOverOnAsteroidBelow asteroidCounter;

    // Текущее количество упавших астероидов
    private int currentFallenAsteroids = 0;

    void Update()
    {
        // Проверяем, изменилось ли количество упавших астероидов
        //if (asteroidCounter.fallenAsteroids != currentFallenAsteroids)
        {
            //currentFallenAsteroids = asteroidCounter.fallenAsteroids;

            // Проверяем, чтобы значение не превышало количество доступных префабов
            if (currentFallenAsteroids > 0 && currentFallenAsteroids <= asteroidPrefabs.Length)
            {
                // Спавним соответствующий префаб
                SpawnAsteroidPrefab(currentFallenAsteroids - 1); // -1 для корректного индекса массива
            }
        }
    }

    void SpawnAsteroidPrefab(int prefabIndex)
    {
        // Получаем случайную точку спавна
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Спавним выбранный префаб
        Instantiate(asteroidPrefabs[prefabIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
