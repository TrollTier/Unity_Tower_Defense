using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        public delegate void HealthHandler(Health health);

        public event HealthHandler OnDeath;

        private float currentValue;
        public float CurrentHealth => currentValue;

        public void Initialize(float startHealth)
        {
            currentValue = startHealth;
        }

        public void AddDamage(float damage)
        {
            currentValue = Math.Max(0, currentValue - damage);
        }
        
        public void Heal(float amount)
        {
            currentValue += amount;
        }

        private void Update()
        {
            if (currentValue <= 0)
            {
                // Give other scripts the change to hook into the death process
                OnDeath?.Invoke(this);
            }

            if (currentValue <= 0)
            {
                Events.SendGameObjectDied(gameObject);

                Destroy(this.gameObject);
            }
        }
    }
}
