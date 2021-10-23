using Assets.Scripts.Gameflow;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets
{
    public static class Events
    {
        public delegate void GameObjectHandler(GameObject spawnedEnemy);
        public delegate void EnemyEventHandler(Enemy monster);
        
        public static event GameObjectHandler EnemySpawned;
        public static event GameObjectHandler GameObjectDied;

        public static event EnemyEventHandler EnemyDied;
        public static event EnemyEventHandler EnemyReachedGoal;

        public static void SendEnemySpawned(GameObject spawnedEnemy)
        {
            EnemySpawned?.Invoke(spawnedEnemy);
        }

        public static void SendGameObjectDied(GameObject diedObject)
        {
            GameObjectDied?.Invoke(diedObject);
        }

        public static void SendEnemyDied(Enemy enemy)
        {
            EnemyDied?.Invoke(enemy);
        }

        public static void SendEnemyReachedGoal(Enemy enemy)
        {
            EnemyReachedGoal?.Invoke(enemy);
        }
    }
}
