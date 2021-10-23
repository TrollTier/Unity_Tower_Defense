using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float baseValue = 50f;

        private float currentValue;


        public void AddDamage(float damage)
        {
            currentValue = Math.Max(0, currentValue - damage);
        }
        
        public void Heal(float amount)
        {
            currentValue = Math.Min(baseValue, currentValue + amount);
        }
        

        private void Start()
        {
            this.currentValue = baseValue;
        }

        private void Update()
        {
            if (currentValue <= 0)
            {
                EventAggregator.SendGameObjectDied(gameObject);

                Destroy(this.gameObject);
            }
        }
    }
}
