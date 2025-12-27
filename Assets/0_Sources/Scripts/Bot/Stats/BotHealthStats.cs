using UnityEngine;

public class BotHealthStats : MonoBehaviour, IUnitHealth
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject model;
    
    public float Health => health;
    public float MaxHealth => maxHealth;
    
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if(health <= 0) return;
        
        health -= damage;
        if (health <= 0) Die();
    }

    public void Die()
    {
        health = 0;
        model.SetActive(false);
    }
}