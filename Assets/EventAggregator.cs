using UnityEngine;

namespace Assets
{
    public static class EventAggregator
    {
        public delegate void GameObjectHandler(GameObject spawnedEnemy);
        
        public static event GameObjectHandler EnemySpawned;
        public static event GameObjectHandler GameObjectDied;

        public static void SendEnemySpawned(GameObject spawnedEnemy)
        {
            EnemySpawned?.Invoke(spawnedEnemy);
        }

        public static void SendGameObjectDied(GameObject diedObject)
        {
            GameObjectDied?.Invoke(diedObject);
        }
    }
}
