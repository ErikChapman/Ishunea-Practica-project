using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform player;
    private float fixedX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fixedX = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = fixedX;

        // �������� 4.12 �� ���������� Y ������
        temp.y = player.position.y + 4.12f;

        transform.position = temp;
    }
}