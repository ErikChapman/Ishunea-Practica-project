using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Canvas gameOverCanvas;  // Ссылка на Canvas с экраном смерти
    public GameObject[] enemyPrefabs;  // Префабы врагов, столкновение с которыми вызовет "Game Over"
    public Canvas[] otherCanvases;  // Канвасы, которые нужно скрыть при активации "Game Over"

    private void Start()
    {
        // Убеждаемся, что Canvas с экраном смерти выключен в начале игры
        gameOverCanvas.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулся ли игрок с объектом, который является врагом
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            if (collision.gameObject.name.Contains(enemyPrefab.name))
            {
                // Останавливаем игру
                Time.timeScale = 0f;

                // Включаем Canvas с экраном смерти
                gameOverCanvas.gameObject.SetActive(true);

                // Скрываем все другие канвасы
                foreach (Canvas canvas in otherCanvases)
                {
                    canvas.gameObject.SetActive(false);
                }

                break;
            }
        }
    }
}
