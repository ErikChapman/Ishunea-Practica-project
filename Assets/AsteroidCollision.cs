using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private Animator animator;
    public bool Contact { get; private set; } = false; // �������� ��������
    public float destroyDelay = 0.5f; // ������������� �������� ��������

    void Start()
    {
        animator = GetComponent<Animator>(); // �������� ��������� Animator
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // �������� �� ��� ����
        {
            Contact = true; // ������������� �������� �������� � true
            animator.SetTrigger("PlayAnimation"); // ������ ��������

            // ������� ���� � �������� ����� ������������
            Destroy(collision.gameObject); // �������� ����
            Destroy(gameObject, destroyDelay); // �������� ��������� � ������������� ���������
        }
    }
}
