using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    public bool isEnemyBullet = false; 

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si es bala del jugador -> NO DEBE destruirse al tocar el escudo
        if (!isEnemyBullet && other.CompareTag("Shield"))
        {
            return; // dejar pasar la bala del jugador
        }

        // Golpear enemigo si es bala del jugador
        if (!isEnemyBullet)
        {
            GruntScript grunt = other.GetComponent<GruntScript>();
            if (grunt != null)
            {
                grunt.Hit();
                DestroyBullet();
                return;
            }
        }

        // Golpear al jugador si es bala enemiga
        if (isEnemyBullet)
        {
            JohnMovement john = other.GetComponent<JohnMovement>();
            if (john != null)
            {
                john.Hit();
                DestroyBullet();
                return;
            }
        }

        DestroyBullet();
    }
}
