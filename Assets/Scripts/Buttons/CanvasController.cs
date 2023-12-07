using UnityEngine;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour
{
    public GameObject canvas;

    public void CloseCanvas()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}