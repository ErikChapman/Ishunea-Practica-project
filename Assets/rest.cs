using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rest : MonoBehaviour
{
    // Start is called before the first frame update



    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        // ��������� ����� ������ (0) ������������� � ������� �����. 
        // ���� ���������� ��������� �� � ������� ����� ������ ����� ����� ���������
    }
}
