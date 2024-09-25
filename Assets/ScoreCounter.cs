using UnityEngine;
using UnityEngine.UI; 

public class HitCounter : MonoBehaviour
{
    public static HitCounter instance; // Статический экземпляр для доступа
    public Text hitCountText;
    public Text bestScoreText;
    public Text altitudeText;
    public Transform player;

    private int asteroidHitCount = 0; // Счётчик попаданий
    private int bestScore = 0;
    private const float heightCorrection = 4.14f;

    // Переменная для множителя очков
    public float scoreMultiplier = 1f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScore();
        UpdateHitCount();
    }

    void Update()
    {
        if (player != null)
        {
            float correctedHeight = player.position.y + heightCorrection;
            altitudeText.text = "Height: " + correctedHeight.ToString("F2") + "m";
        }
    }

    public void AddHit()
    {
        // Увеличиваем счётчик с учётом множителя
        asteroidHitCount += Mathf.RoundToInt(1 * scoreMultiplier);
        UpdateHitCount();

        if (asteroidHitCount > bestScore)
        {
            bestScore = asteroidHitCount;
            SaveBestScore();
            UpdateBestScore();
        }
    }

    void UpdateHitCount()
    {
        hitCountText.text = "Hits: " + asteroidHitCount.ToString();
    }

    void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();
    }

    void UpdateBestScore()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    public void ResetScore()
    {
        asteroidHitCount = 0;
        UpdateHitCount();
    }
}
