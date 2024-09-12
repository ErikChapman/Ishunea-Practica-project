using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverTextPrefab;  // ������ ������� "Game Over"
    public Transform spawnPoint;  // ����� ������ ��� ������� "Game Over"
    public GameObject[] enemyPrefabs;  // �������, ������������ � �������� �������� � "Game Over"

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ��������� �� ������, � ������� ���������� �����, � ����� �� ��������� ��������
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            if (collision.gameObject.name.Contains(enemyPrefab.name))
            {
                // ������������� ����
                Time.timeScale = 0;

                // ������� ������� "Game Over" � ��������� �����
                Instantiate(gameOverTextPrefab, spawnPoint.position, Quaternion.identity);

                break;
            }
        }
    }
}
