using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private Animator animator;
    private Collider2D asteroidCollider;
    public bool Contact { get; private set; } = false; // Параметр контакта
    public float destroyDelay = 0.5f; // Настраиваемая задержка удаления

    void Start()
    {
        animator = GetComponent<Animator>(); // Получаем компонент Animator
        asteroidCollider = GetComponent<Collider2D>(); // Получаем компонент Collider2D
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Проверка на тэг пули
        {
            Contact = true; // Устанавливаем параметр контакта в true
            animator.SetTrigger("PlayAnimation"); // Запуск анимации
            asteroidCollider.enabled = false; // Отключаем коллайдер

            HitCounter.instance.AddHit();
            Destroy(collision.gameObject); // Удаление пули
            Destroy(gameObject, destroyDelay); // Удаление астероида с настраиваемой задержкой
        }
    }
}
