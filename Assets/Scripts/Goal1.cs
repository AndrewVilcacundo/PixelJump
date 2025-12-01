using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGoal : MonoBehaviour
{
    public string nextSceneName = "Nivel_01_B_PuzzleFinal";
    public bool showVictoryScreen = true; // Mostrar pantalla de victoria

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Nivel completado!");

            if (showVictoryScreen && GameManager.Instance != null)
            {
                // Mostrar pantalla de victoria
                GameManager.Instance.Victory();
            }
            else
            {
                // Cargar directamente la siguiente escena
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}