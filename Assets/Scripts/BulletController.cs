using UnityEngine;

public class BulletTimer : MonoBehaviour
{
    // ����� ����� ���� � ��������
    public float lifetime = 5f; // 5 ����� = 300 ������

    private void Start()
    {
        // ��������� ������ �� ��������
        Destroy(gameObject, lifetime);
    }
}
