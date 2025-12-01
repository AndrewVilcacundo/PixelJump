using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;

    [Header("Shield System")]
    public GameObject Shield;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 5;
    private bool isDead = false;

    private int StarCount = 0;
    private bool ShieldActive = false;
    private int ShieldHitsLeft = 3;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        ResetShield();
    }

    private void Update()
    {
        if (isDead) return;

        // Caída fuera del mapa
        if (transform.position.y < -10f)
        {
            Die();
            return;
        }

        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (Horizontal > 0.0f)
            transform.localScale = new Vector3(1f, 1f, 1f);

        Animator.SetBool("running", Horizontal != 0);

        // Saltar
        Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
            Jump();

        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

        // ACTIVAR ESCUDO CON R
        if (Input.GetKeyDown(KeyCode.R) && StarCount >= 2 && !ShieldActive)
        {
            ActivateShield();
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction =
            transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab,
            transform.position + direction * 0.1f,
            Quaternion.identity);

        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    
    public void Hit()
    {
        if (isDead) return;

        // Si el escudo está activo → NO recibir daño
        if (ShieldActive)
        {
            // NO bajas durabilidad aquí
            return;
        }

        Health--;

        if (Health <= 0)
            Die();
    }


    private void Die()
    {
        if (isDead) return;

        isDead = true;

        Rigidbody2D.velocity = Vector2.zero;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        if (GameManager.Instance != null)
            GameManager.Instance.GameOver();
    }

    // SISTEMA DE ESTRELLAS + ESCUDO

    public void AddStar()
    {
        StarCount++;
        Debug.Log("Estrellas: " + StarCount);
    }

    private void ActivateShield()
    {
        StarCount -= 2;
        ShieldActive = true;
        ShieldHitsLeft = 3;

        if (Shield != null)
            Shield.SetActive(true);

        Debug.Log("Escudo ACTIVADO (3 impactos). Estrellas restantes: " + StarCount);
    }

    public void ShieldHit()
    {
        if (!ShieldActive) return;

        ShieldHitsLeft--;

        Debug.Log("Impacto al escudo. Quedan: " + ShieldHitsLeft);

        if (ShieldHitsLeft <= 0)
            DeactivateShield();
    }

    private void DeactivateShield()
    {
        ShieldActive = false;

        if (Shield != null)
            Shield.SetActive(false);

        Debug.Log("Escudo DESACTIVADO");
    }

    // RESET PARA RETRY

    public void ResetAll()
    {
        StarCount = 0;
        Health = 5;
        isDead = false;

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        ResetShield();
    }

    private void ResetShield()
    {
        ShieldActive = false;
        ShieldHitsLeft = 3;

        if (Shield != null)
            Shield.SetActive(false);
    }
}
