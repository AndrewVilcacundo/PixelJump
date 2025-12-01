using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGoal : MonoBehaviour
{
    public string nextSceneName = "Nivel_01_B_PuzzleFinal";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Nivel completado. Cargando siguiente escena...");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
