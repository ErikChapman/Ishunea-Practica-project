using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverTextPrefab;  // Префаб надписи "Game Over"
    public Transform spawnPoint;  // Точка спавна для надписи "Game Over"
    public GameObject[] enemyPrefabs;  // Префабы, столкновение с которыми приведет к "Game Over"

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, совпадает ли объект, с которым столкнулся игрок, с одним из указанных префабов
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            if (collision.gameObject.name.Contains(enemyPrefab.name))
            {
                // Останавливаем игру
                Time.timeScale = 0;

                // Спавним надпись "Game Over" в указанной точке
                Instantiate(gameOverTextPrefab, spawnPoint.position, Quaternion.identity);

                break;
            }
        }
    }
}
