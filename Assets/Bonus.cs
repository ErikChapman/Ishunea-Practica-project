using UnityEngine;

public class Bonus : MonoBehaviour
{
    private RandomSpawner randomSpawner; // ������ �� RandomSpawner

    // ���������, �������� �� ������ � ����� "Player"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ������� ��������� � �������
            Debug.Log("�� ��������� �����!");

            // ����� ������ � ����������� RandomSpawner
            randomSpawner = FindObjectOfType<RandomSpawner>();

            if (randomSpawner != null)
            {
                // ����������� HP
                randomSpawner.currentHP += 34;

                // ���������, ��� HP �� ��������� ��������
                if (randomSpawner.currentHP > randomSpawner.maxHP)
                {
                    randomSpawner.currentHP = randomSpawner.maxHP;
                }

                // ��������� ������� ��������
                randomSpawner.hpBar.fillAmount = randomSpawner.currentHP / randomSpawner.maxHP;
            }

            // ������� ����� ����� ����, ��� �� ��� ��������
            Destroy(gameObject);
        }
    }
}
