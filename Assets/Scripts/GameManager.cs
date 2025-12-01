using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverUI;
    public GameObject victoryUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
            Debug.Log("GameOver UI ocultada al inicio");
        }
        if (victoryUI != null)
        {
            victoryUI.SetActive(false);
            Debug.Log("Victory UI ocultada al inicio");
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver llamado!");
        Time.timeScale = 0f; // Pausa el juego
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("GameOver UI activada");
        }
        else
        {
            Debug.LogError("GameOver UI no está asignada en el GameManager!");
        }
    }

    public void Victory()
    {
        Time.timeScale = 0f; // Pausa el juego
        if (victoryUI != null) victoryUI.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Reanuda el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel(string sceneName)
    {
        Time.timeScale = 1f; // Reanuda el juego
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}