using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private Animator animator;
    private Collider2D asteroidCollider;
    public bool Contact { get; private set; } = false; // �������� ��������
    public float destroyDelay = 0.5f; // ������������� �������� ��������

    public AudioSource audioSource; // ��������� ���������� ��� AudioSource

    void Start()
    {
        animator = GetComponent<Animator>(); // �������� ��������� Animator
        asteroidCollider = GetComponent<Collider2D>(); // �������� ��������� Collider2D

        // ���� AudioSource �� �������� � ����������, ������� ����� ��� �� �������
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // �������� �� ��� ����
        {
            Contact = true; // ������������� �������� �������� � true
            animator.SetTrigger("PlayAnimation"); // ������ ��������
            asteroidCollider.enabled = false; // ��������� ���������

            // ����������� ���� ����� ��������� AudioSource, ���� �� ��������
            if (audioSource != null)
            {
                audioSource.Play();
            }

            HitCounter.instance.AddHit();
            Destroy(collision.gameObject); // �������� ����
            Destroy(gameObject, destroyDelay); // �������� ��������� � ������������� ���������
        }
    }
}
