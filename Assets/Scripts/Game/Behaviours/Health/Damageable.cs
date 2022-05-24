using UnityEngine;
using System;

namespace SmashStronghold.Game.Behaviours
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField]
        private int health = 100;

        [SerializeField]
        private int maxHealth = 100;

        public int MaxHealth
        {
            get => maxHealth;
            private set => maxHealth = value;
        }
        
        public int Health
        {
            get => health;
            private set => health = value;
        }

        public event Action<Damageable> HealthZeroOrBelow;
        public event Action<Damageable> Damaged;
        public event Action<Damageable> Healed;

        public void SetStartingHealth(int amount)
        {
            MaxHealth = amount;
            Health = amount;
        }

        /// <summary>
        /// Subtracts absolute amount to entity health
        /// </summary>
        public void Damage(int amount)
        {
            Health -= Mathf.Abs(amount);
            if (Health <= 0)
            {
                HealthZeroOrBelow?.Invoke(this);
                return;
            }
            Damaged?.Invoke(this);
        }

        /// <summary>
        /// Adds absolute amount to entity health. 
        /// If above maximum level, then sets it to maximum
        /// </summary>
        public void Heal(int amount)
        {
            Health += Mathf.Abs(amount);
            if (Health > MaxHealth) Health = MaxHealth;
            Healed?.Invoke(this);
        }
    }
}

