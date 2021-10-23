using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class TowerAIData
    {
        private static List<GameObject> enemies = new List<GameObject>();

        static TowerAIData()
        {
            Events.EnemySpawned += enemy => enemies.Add(enemy);
            Events.GameObjectDied += obj => enemies.Remove(obj);
        }

        public static GameObject GetClosestEnemy(Vector3 towerLocation)
        {
            GameObject closest = null;
            float closestDistance = float.MaxValue;

            foreach (var enemy in enemies)
            {
                var distance = Vector3.Distance(enemy.transform.position, towerLocation);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = enemy;
                }
            }

            return closest;
        }
    }
}
