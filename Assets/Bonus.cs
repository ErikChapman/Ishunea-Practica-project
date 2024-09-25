using UnityEngine;

public class Bonus : MonoBehaviour
{
    private RandomSpawner randomSpawner; // Ссылка на RandomSpawner

    // Проверяем, коснулся ли объект с тегом "Player"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Выводим сообщение в консоль
            Debug.Log("Вы подобрали бонус!");

            // Найти объект с компонентом RandomSpawner
            randomSpawner = FindObjectOfType<RandomSpawner>();

            if (randomSpawner != null)
            {
                // Увеличиваем HP
                randomSpawner.currentHP += 34;

                // Убедитесь, что HP не превышает максимум
                if (randomSpawner.currentHP > randomSpawner.maxHP)
                {
                    randomSpawner.currentHP = randomSpawner.maxHP;
                }

                // Обновляем полоску здоровья
                randomSpawner.hpBar.fillAmount = randomSpawner.currentHP / randomSpawner.maxHP;
            }

            // Удаляем бонус после того, как он был подобран
            Destroy(gameObject);
        }
    }
}
