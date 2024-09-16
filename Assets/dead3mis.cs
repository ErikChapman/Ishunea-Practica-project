using UnityEngine;

public class GameOverOnAsteroidBelow : MonoBehaviour
{
    public string playerTag = "Player";
    public float gameOverDelay = 0f;

    private Transform playerTransform;
    private int fallenAsteroids = 0;
    private const int requiredFallenAsteroids = 3;
    private bool hasCounted = false;

    void Start()
    {
        // ������ ������ � ����� Player � �������� ��� ���������
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player object with tag " + playerTag + " not found.");
        }
    }

    void Update()
    {
        if (playerTransform != null && !hasCounted)
        {
            // ���������, ��� �������� ���� ������ �� Y
            if (transform.position.y < playerTransform.position.y)
            {
                // ����������� ������� ������� ����������
                fallenAsteroids++;

                // ���������, �������� �� �� ������� ����������
                if (fallenAsteroids >= requiredFallenAsteroids)
                {
                    // ������������� ����
                    Invoke("GameOver", gameOverDelay);
                    Time.timeScale = 0;
                    hasCounted = true; // ������������� ������� ��� ����� ���������
                }

                // ������� ��������, ����� �������� ���������� ��������
                Destroy(gameObject);
            }
        }
    }

    void GameOver()
    {
        // ��� ��� ��� ��������� ����
        Debug.Log("Game Over");
    }
}
