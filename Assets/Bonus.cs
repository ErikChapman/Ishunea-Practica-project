using UnityEngine;

public class Bonus : MonoBehaviour
{
    // ���������, �������� �� ������ � ����� "Player"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ������� ��������� � �������
            Debug.Log("�� ��������� �����!");

            // ����� ����� �������� ������ ��� ���������� ������� ������

            // ������� ����� ����� ����, ��� �� ��� ��������
            Destroy(gameObject);
        }
    }
}
