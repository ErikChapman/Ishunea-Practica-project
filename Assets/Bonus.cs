using UnityEngine;

public class Bonus : MonoBehaviour
{
    // Проверяем, коснулся ли объект с тегом "Player"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Выводим сообщение в консоль
            Debug.Log("Вы подобрали бонус!");

            // Здесь можно добавить логику для применения эффекта бонуса

            // Удаляем бонус после того, как он был подобран
            Destroy(gameObject);
        }
    }
}
