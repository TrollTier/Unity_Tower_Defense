using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Gameflow
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private EnemyData data;
        public EnemyData Data => data;

        private void Start()
        {
            var health = GetComponent<Health>();
            
            if (health != null)
            {
                health.Initialize(data.Health);

                health.OnDeath += SendEnemyDeathEvent;
            }
        }

        private void OnDestroy()
        {
            var health = GetComponent<Health>();

            if (health != null)
            {
                health.OnDeath -= SendEnemyDeathEvent;
            }
        }

        private void SendEnemyDeathEvent(Health health)
        {
            Events.SendEnemyDied(this);
        }
    }
}
