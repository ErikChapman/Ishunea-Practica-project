using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Canvas gameOverCanvas;  // ������ �� Canvas � ������� ������
    public GameObject[] enemyPrefabs;  // ������� ������, ������������ � �������� ������� "Game Over"
    public Canvas[] otherCanvases;  // �������, ������� ����� ������ ��� ��������� "Game Over"

    private void Start()
    {
        // ����������, ��� Canvas � ������� ������ �������� � ������ ����
        gameOverCanvas.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ���������� �� ����� � ��������, ������� �������� ������
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            if (collision.gameObject.name.Contains(enemyPrefab.name))
            {
                // ������������� ����
                Time.timeScale = 0f;

                // �������� Canvas � ������� ������
                gameOverCanvas.gameObject.SetActive(true);

                // �������� ��� ������ �������
                foreach (Canvas canvas in otherCanvases)
                {
                    canvas.gameObject.SetActive(false);
                }

                break;
            }
        }
    }
}
