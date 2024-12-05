using System;
using UnityEngine;

public class HealthModel : IDamagable, IHealable
{
    public static event Action OnTakedDamage;
    public static event Action OnDie;

    private int health { get; set; }
    private int damageAmount = 1;
    private int healAmount = 1;

    public HealthModel(int health)
    {
        this.health = health;
    }

    public void TakeDamage()
    {
        health -= Mathf.Abs(damageAmount);

        OnTakedDamage?.Invoke();

        if (health <= 0)
        {
            health = 0;

            OnDie?.Invoke();
        }
    }
    public void Heal()
    {
        health += Mathf.Abs(healAmount);
    }
}