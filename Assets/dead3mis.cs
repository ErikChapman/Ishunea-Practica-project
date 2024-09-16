using UnityEngine;

public class GameOverOnAsteroidBelow : MonoBehaviour
{
    public string playerTag = "Player";
    public float gameOverDelay = 0f;

    private Transform playerTransform;
    private int fallenAsteroids = 0;
    private const int requiredFallenAsteroids = 3;
    private bool hasCounted = false;

    void Start()
    {
        // Найдем объект с тегом Player и сохраним его трансформ
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player object with tag " + playerTag + " not found.");
        }
    }

    void Update()
    {
        if (playerTransform != null && !hasCounted)
        {
            // Проверяем, что астероид ниже игрока по Y
            if (transform.position.y < playerTransform.position.y)
            {
                // Увеличиваем счётчик упавших астероидов
                fallenAsteroids++;

                // Проверяем, достигли ли мы нужного количества
                if (fallenAsteroids >= requiredFallenAsteroids)
                {
                    // Останавливаем игру
                    Invoke("GameOver", gameOverDelay);
                    Time.timeScale = 0;
                    hasCounted = true; // Останавливаем подсчёт для этого астероида
                }

                // Удаляем астероид, чтобы избежать повторного подсчета
                Destroy(gameObject);
            }
        }
    }

    void GameOver()
    {
        // Ваш код для окончания игры
        Debug.Log("Game Over");
    }
}
