using UnityEngine;

public class EnemyShadow : MonoBehaviour
{
    public float speed = 1.5f;              // Velocidad de movimiento
    public float detectionRange = 4f;       // Distancia para detectar al jugador
    public float lightDamageTime = 1f;      // Tiempo que tarda en desaparecer cuando lo iluminas

    private Transform player;
    private bool insideLight = false;
    private float lightTimer = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        // Busca al jugador por TAG (asegúrate de ponerle tag "Player")
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null)
            return;

        float dist = Vector2.Distance(transform.position, player.position);

        // Si está siendo iluminado → empieza a desaparecer
        if (insideLight)
        {
            lightTimer += Time.deltaTime;

            if (lightTimer >= lightDamageTime)
            {
                // Desaparece al ser iluminado
                Destroy(gameObject);
            }

            return;
        }

        // Si está lejos → no hace nada
        if (dist > detectionRange)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Perseguir al jugador
        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * speed;
    }

    // Llamar cuando la habilidad "Iluminar" toque al enemigo
    public void ApplyLight()
    {
        insideLight = true;
        rb.velocity = Vector2.zero; // deja de moverse
    }

    // Si el jugador entra en un área de luz constante
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LightArea"))
        {
            insideLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LightArea"))
        {
            insideLight = false;
            lightTimer = 0;
        }
    }
}
