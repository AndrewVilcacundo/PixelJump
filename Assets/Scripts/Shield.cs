using UnityEngine;

public class ShieldBlock : MonoBehaviour
{
    public JohnMovement player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        BulletScript bullet = other.GetComponent<BulletScript>();
        if (bullet == null) return;

        // Detectar balas ENEMIGAS
        if (bullet.isEnemyBullet)
        {
            bullet.DestroyBullet();
            player.ShieldHit();
        }
        // Si es bala del jugador -> NO HACER NADA
    }
}
