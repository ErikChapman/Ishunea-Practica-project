using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private Animator animator;
    public bool Contact { get; private set; } = false; // Параметр контакта
    public float destroyDelay = 0.5f; // Настраиваемая задержка удаления

    void Start()
    {
        animator = GetComponent<Animator>(); // Получаем компонент Animator
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Проверка на тэг пули
        {
            Contact = true; // Устанавливаем параметр контакта в true
            animator.SetTrigger("PlayAnimation"); // Запуск анимации

            // Удаляем пулю и астероид после столкновения
            Destroy(collision.gameObject); // Удаление пули
            Destroy(gameObject, destroyDelay); // Удаление астероида с настраиваемой задержкой
        }
    }
}
