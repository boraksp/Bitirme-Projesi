using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the GameOverPanel

    private void Start()
    {
        gameOverPanel.SetActive(false); // Ensure the panel is hidden at start

    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Show the Game Over panel
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        // Exit the application
        Application.Quit();
        Debug.Log("exitted");
    }
    //public void TogglePanel()
    //{
    //    gameOverPanel.SetActive(!gameOverPanel.activeSelf);
    //    Time.timeScale = 0f;
    //}
}
