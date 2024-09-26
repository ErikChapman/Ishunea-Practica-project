using UnityEngine;
using System.Collections;

public class TimeSlowBonus : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // ��������� ��������� ����� (��������, 0.5 = � ��� ���� ���������)
    public float slowDownDuration = 5f; // ����� �������� ������ (� ��������)

    private bool isTimeSlowed = false; // ���� ��� ��������, ��������� �� �����
    private SpriteRenderer spriteRenderer; // ��������� ������� ��� �������

    void Start()
    {
        // ������� SpriteRenderer ���������� ������
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // ����� ��� ��������� ���������� �������
    public void ActivateTimeSlow()
    {
        if (!isTimeSlowed) // ��������, ����� �� ������������ ��������, ���� ��� ���������
        {
            Debug.Log("Starting Time Slow Coroutine");
            StartCoroutine(SlowTimeCoroutine()); // ��������� �������� ��� ���������� �������
        }
    }

    // ��������, ������� ��������� ����� �� ����������� �����
    IEnumerator SlowTimeCoroutine()
    {
        isTimeSlowed = true;

        // ��������� �����
        Debug.Log("Time Slow Activated at Time.timeScale: " + Time.timeScale);
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; // ������������ ���������� ��� �������

        // ��� ��������� ���������� �������� ������ (�� �������� �������)
        Debug.Log("Waiting for " + slowDownDuration + " real seconds...");
        yield return new WaitForSecondsRealtime(slowDownDuration);

        // ��������������� ���������� ������� �������
        Debug.Log("Restoring normal time scale");
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; // ��������������� ���������� ��� �������
        Destroy(gameObject); // ������� ����� ����� ���������

        isTimeSlowed = false;
        Debug.Log("Time scale restored, Coroutine finished");
    }

    // ����� ��� ��������� ������������ � �������
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���� ������ �������� ������
        {
            ActivateTimeSlow(); // ���������� Time Slow

            // �������� �������� ������ (SpriteRenderer)
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false; // ��������� ����������� �������
            }
        }
    }
}
