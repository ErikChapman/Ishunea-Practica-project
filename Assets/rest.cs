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
        // Загружает самую первую (0) установленную в проекте сцену. 
        // Если необходимо загрузить не её укажите какую именно сцену нужно загрузить
    }
}
