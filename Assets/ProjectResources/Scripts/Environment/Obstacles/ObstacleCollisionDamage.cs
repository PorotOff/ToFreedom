using UnityEngine;

public class ObstacleCollisionDamage : MonoBehaviour, IObstacle
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        DoDamage(other.gameObject.GetComponent<IDamagable>());
    }

    public void DoDamage(IDamagable damagable)
    {
        if (damagable != null)
        {
            damagable.TakeDamage();
        }
    }
}