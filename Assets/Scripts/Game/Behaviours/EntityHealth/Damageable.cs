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

        public int MaxHealth { get => maxHealth; private set => maxHealth = value; }
        public int Health { get => health; private set => health = value; }

        public event Action HealthZeroOrBelow;
        public event Action Damaged;
        public event Action Healed;

        /// <summary>
        /// Subtracts absolute amount to entity health
        /// </summary>
        public void Damage(int amount)
        {
            Health -= Mathf.Abs(amount);
            if (Health <= 0) 
            {
                HealthZeroOrBelow?.Invoke();
                return;
            }
            Damaged?.Invoke();
        }

        /// <summary>
        /// Adds absolute amount to entity health. 
        /// If above maximum level, then sets it to maximum
        /// </summary>
        public void Heal(int amount)
        {
            Health += Mathf.Abs(amount);
            if(Health > MaxHealth) Health = MaxHealth;
            Healed?.Invoke();
        }
    }
}

