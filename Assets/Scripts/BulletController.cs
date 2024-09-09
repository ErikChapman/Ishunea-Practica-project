using UnityEngine;

public class BulletTimer : MonoBehaviour
{
    // Время жизни пули в секундах
    public float lifetime = 5f; // 5 минут = 300 секунд

    private void Start()
    {
        // Запускаем таймер на удаление
        Destroy(gameObject, lifetime);
    }
}
