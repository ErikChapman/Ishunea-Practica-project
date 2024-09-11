using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text gameOverText; // Drag the Text UI element here in the Inspector

    void Start()
    {
        // Скрываем текст в начале
        gameOverText.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, что объект, с которым произошло столкновение, имеет тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Отображаем текст "Проигрыш"
            gameOverText.gameObject.SetActive(true);
            // Останавливаем игру
            Time.timeScale = 0f;
        }
    }
}
