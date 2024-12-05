using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private HealthModel healthModel;

    [Header("Health settings")]
    [SerializeField] private int health;

    private void Awake()
    {
        healthModel = new HealthModel(health);
    }
    
    public void TakeDamage()
    {
        healthModel.TakeDamage();
    }
    
}