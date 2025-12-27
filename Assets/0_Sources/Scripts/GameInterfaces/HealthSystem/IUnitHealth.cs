using UnityEngine;

public interface IUnitHealth
{
   public float Health { get; } 
   public float MaxHealth { get; }

   public void TakeDamage(float damage);
   public void Die();
}
