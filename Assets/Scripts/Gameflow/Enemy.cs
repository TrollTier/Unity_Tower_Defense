using Assets.Scripts.Data;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.AI;

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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<Goal>(out _))
            {
                Events.SendEnemyReachedGoal(this);
                Events.SendGameObjectDied(gameObject);

                Destroy(gameObject);
            }
        }
    }
}
