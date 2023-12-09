using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public Canvas pauseCanvas; 
    public bool isPaused = false;

    private void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f;
                pauseCanvas.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseCanvas.gameObject.SetActive(false);
            }
        }
    }
}
