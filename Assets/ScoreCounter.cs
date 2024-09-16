using UnityEngine;
using TMPro; // Для работы с TextMeshPro

public class HitCounter : MonoBehaviour
{
    public static HitCounter instance; // Статический экземпляр для доступа
    public TextMeshProUGUI hitCountText; // TMP для текущего счёта
    public TextMeshProUGUI bestScoreText; // TMP для лучшего счёта
    public TextMeshProUGUI altitudeText; // TMP для отображения высоты
    public Transform player; // Ссылка на объект игрока

    private int asteroidHitCount = 0; // Счётчик попаданий
    private int bestScore = 0; // Лучший счёт
    private const float heightCorrection = 4.14f; // Значение для коррекции высоты

    void Awake()
    {
        // Устанавливаем Singleton, чтобы этот скрипт был доступен в любом месте
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Удаляем дубликаты
        }
    }

    void Start()
    {
        // Загружаем лучший счёт, если он есть
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScore(); // Обновляем отображение лучшего счёта
        UpdateHitCount();  // Обновляем текст текущего счёта
    }

    void Update()
    {
        // Обновляем текстовое поле с текущей высотой игрока с коррекцией
        if (player != null)
        {
            float correctedHeight = player.position.y + heightCorrection;
            altitudeText.text = "Height: " + correctedHeight.ToString("F2") + "m";
        }
    }

    // Метод для увеличения счётчика попаданий
    public void AddHit()
    {
        asteroidHitCount++; // Увеличиваем счётчик
        UpdateHitCount(); // Обновляем текстовое поле

        // Проверяем, если текущий счёт больше лучшег
        if (asteroidHitCount > bestScore)
        {
            bestScore = asteroidHitCount;
            SaveBestScore(); // Сохраняем новый лучший счёт
            UpdateBestScore(); // Обновляем отображение лучшего счёта
        }
    }

    // Обновление текстового поля для текущего счёта
    void UpdateHitCount()
    {
        hitCountText.text = "Hits: " + asteroidHitCount.ToString();
    }

    // Сохранение лучшего счёта в PlayerPrefs
    void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore); // Сохраняем лучший счёт
        PlayerPrefs.Save(); // Сохраняем изменения на диск
    }

    // Обновление текстового поля для лучшего счёта
    void UpdateBestScore()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    // Метод для сброса текущего счёта (если нужно)
    public void ResetScore()
    {
        asteroidHitCount = 0;
        UpdateHitCount();
    }
}
