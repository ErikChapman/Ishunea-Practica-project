using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text gameOverText; // Drag the Text UI element here in the Inspector

    void Start()
    {
        // �������� ����� � ������
        gameOverText.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ��� ������, � ������� ��������� ������������, ����� ��� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���������� ����� "��������"
            gameOverText.gameObject.SetActive(true);
            // ������������� ����
            Time.timeScale = 0f;
        }
    }
}
