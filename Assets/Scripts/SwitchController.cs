using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject linkedObject;     // objeto que activa o desactiva
    public bool toggle = true;          // si es interruptor de encendido/apagado
    public bool oneUse = false;         // si solo se puede usar una vez

    private bool used = false;
    private bool state = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player debe tener tag "Player"
        if (!collision.CompareTag("Player"))
            return;

        if (oneUse && used)
            return;

        used = true;

        if (toggle)
        {
            state = !state;
            linkedObject.SetActive(state);
        }
        else
        {
            // Activación momentánea → ejemplo puente, luz, plataforma
            linkedObject.SetActive(true);
        }

        // Opcional: animación o cambio de color del interruptor
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (!toggle)
        {
            // Si NO es tipo toggle, al salir se desactiva
            linkedObject.SetActive(false);
        }

        // Volver al color normal
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
