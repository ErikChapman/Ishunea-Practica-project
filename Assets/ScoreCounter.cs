using UnityEngine;
using TMPro; // ��� ������ � TextMeshPro

public class HitCounter : MonoBehaviour
{
    public static HitCounter instance; // ����������� ��������� ��� �������
    public TextMeshProUGUI hitCountText; // TMP ��� �������� �����
    public TextMeshProUGUI bestScoreText; // TMP ��� ������� �����
    public TextMeshProUGUI altitudeText; // TMP ��� ����������� ������
    public Transform player; // ������ �� ������ ������

    private int asteroidHitCount = 0; // ������� ���������
    private int bestScore = 0; // ������ ����
    private const float heightCorrection = 4.14f; // �������� ��� ��������� ������

    void Awake()
    {
        // ������������� Singleton, ����� ���� ������ ��� �������� � ����� �����
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // ������� ���������
        }
    }

    void Start()
    {
        // ��������� ������ ����, ���� �� ����
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScore(); // ��������� ����������� ������� �����
        UpdateHitCount();  // ��������� ����� �������� �����
    }

    void Update()
    {
        // ��������� ��������� ���� � ������� ������� ������ � ����������
        if (player != null)
        {
            float correctedHeight = player.position.y + heightCorrection;
            altitudeText.text = "Height: " + correctedHeight.ToString("F2") + "m";
        }
    }

    // ����� ��� ���������� �������� ���������
    public void AddHit()
    {
        asteroidHitCount++; // ����������� �������
        UpdateHitCount(); // ��������� ��������� ����

        // ���������, ���� ������� ���� ������ ������
        if (asteroidHitCount > bestScore)
        {
            bestScore = asteroidHitCount;
            SaveBestScore(); // ��������� ����� ������ ����
            UpdateBestScore(); // ��������� ����������� ������� �����
        }
    }

    // ���������� ���������� ���� ��� �������� �����
    void UpdateHitCount()
    {
        hitCountText.text = "Hits: " + asteroidHitCount.ToString();
    }

    // ���������� ������� ����� � PlayerPrefs
    void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore); // ��������� ������ ����
        PlayerPrefs.Save(); // ��������� ��������� �� ����
    }

    // ���������� ���������� ���� ��� ������� �����
    void UpdateBestScore()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    // ����� ��� ������ �������� ����� (���� �����)
    public void ResetScore()
    {
        asteroidHitCount = 0;
        UpdateHitCount();
    }
}
