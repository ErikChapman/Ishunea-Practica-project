using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] balls;
    public List<Transform> spawnPoints;
    public float[] spawnIntervals; // Интервалы спауна для каждого шара
    public float distanceBelowPlayer = 30f; // Расстояние ниже игрока для удаления астероидов

    private List<Transform> originalSpawnPoints;
    private GameObject player;

    private void Start()
    {
        originalSpawnPoints = new List<Transform>(spawnPoints);
        player = GameObject.FindGameObjectWithTag("Player"); // Найти игрока по тегу
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (true) // Бесконечный цикл
        {
            // Проверяем, есть ли еще точки спауна
            if (spawnPoints.Count == 0)
            {
                // Восстанавливаем точки спауна
                spawnPoints = new List<Transform>(originalSpawnPoints);
            }

            for (int i = 0; i < balls.Length; i++)
            {
                if (i < spawnIntervals.Length)
                {
                    yield return new WaitForSeconds(spawnIntervals[i]);

                    if (spawnPoints.Count > 0)
                    {
                        var spawn = Random.Range(0, spawnPoints.Count);
                        GameObject ball = Instantiate(balls[i], spawnPoints[spawn].transform.position, Quaternion.identity);
                        DestroyOffScreen(ball); // Проверяем, если объект должен быть удален
                        spawnPoints.RemoveAt(spawn);
                    }
                }
                else
                {
                    Debug.LogWarning("Не указаны интервалы спауна для всех шаров.");
                    yield break;
                }
            }
        }
    }

    private void DestroyOffScreen(GameObject obj)
    {
        StartCoroutine(CheckAndDestroy(obj));
    }

    IEnumerator CheckAndDestroy(GameObject obj)
    {
        while (true)
        {
            if (player != null)
            {
                float playerY = player.transform.position.y;
                float objectY = obj.transform.position.y;

                if (objectY < playerY - distanceBelowPlayer)
                {
                    Destroy(obj);
                    yield break;
                }
            }
            yield return new WaitForSeconds(1f); // Проверяем раз в секунду
        }
    }
}
