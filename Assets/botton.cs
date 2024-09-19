using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    public Canvas canvasToEnable;  // Canvas, который нужно включить
    public Canvas canvasToDisable; // Canvas, который нужно отключить

    public void SwitchCanvases()
    {
        // ¬ключаем нужный Canvas
        if (canvasToEnable != null)
        {
            canvasToEnable.gameObject.SetActive(true);
        }

        // ќтключаем другой Canvas
        if (canvasToDisable != null)
        {
            canvasToDisable.gameObject.SetActive(false);
        }
    }
}
