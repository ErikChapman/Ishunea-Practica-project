using UnityEngine;
using System.Collections;

public class TimeSlowBonus : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Насколько замедляем время (например, 0.5 = в два раза медленнее)
    public float slowDownDuration = 5f; // Время действия бонуса (в секундах)

    private bool isTimeSlowed = false; // Флаг для проверки, замедлено ли время
    private SpriteRenderer spriteRenderer; // Компонент рендера для скрытия

    void Start()
    {
        // Находим SpriteRenderer компонента бонуса
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Метод для активации замедления времени
    public void ActivateTimeSlow()
    {
        if (!isTimeSlowed) // Проверка, чтобы не активировать повторно, если уже замедлено
        {
            Debug.Log("Starting Time Slow Coroutine");
            StartCoroutine(SlowTimeCoroutine()); // Запускаем корутину для замедления времени
        }
    }

    // Корутина, которая замедляет время на определённое время
    IEnumerator SlowTimeCoroutine()
    {
        isTimeSlowed = true;

        // Замедляем время
        Debug.Log("Time Slow Activated at Time.timeScale: " + Time.timeScale);
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; // Корректируем физический шаг времени

        // Ждём указанное количество реальных секунд (не игрового времени)
        Debug.Log("Waiting for " + slowDownDuration + " real seconds...");
        yield return new WaitForSecondsRealtime(slowDownDuration);

        // Восстанавливаем нормальное течение времени
        Debug.Log("Restoring normal time scale");
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; // Восстанавливаем физический шаг времени
        Destroy(gameObject); // Удаляем бонус после активации

        isTimeSlowed = false;
        Debug.Log("Time scale restored, Coroutine finished");
    }

    // Метод для обработки столкновений с игроком
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Если объект касается игрока
        {
            ActivateTimeSlow(); // Активируем Time Slow

            // Скрываем модельку бонуса (SpriteRenderer)
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false; // Отключаем отображение спрайта
            }
        }
    }
}
