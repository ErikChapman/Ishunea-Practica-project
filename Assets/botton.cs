using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    public Canvas canvasToEnable;  // Canvas, ������� ����� ��������
    public Canvas canvasToDisable; // Canvas, ������� ����� ���������

    public void SwitchCanvases()
    {
        // �������� ������ Canvas
        if (canvasToEnable != null)
        {
            canvasToEnable.gameObject.SetActive(true);
        }

        // ��������� ������ Canvas
        if (canvasToDisable != null)
        {
            canvasToDisable.gameObject.SetActive(false);
        }
    }
}
