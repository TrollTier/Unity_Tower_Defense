using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Gameflow
{
    public class Level : MonoBehaviour
    {
        public delegate void LevelEventHandler(Level level);

        public event LevelEventHandler OnLivesChanged;

        [SerializeField]
        private int lifesOnStart = 50;

        private int currentLifes = 50;
        public int CurrentLifes => currentLifes;

        private void Start()
        {
            currentLifes = lifesOnStart;

            Events.EnemyReachedGoal += HandleEnemyReachedGoal;
        }

        private void OnDestroy()
        {
            Events.EnemyReachedGoal -= HandleEnemyReachedGoal;
        }

        private void HandleEnemyReachedGoal(Enemy enemy)
        {
            currentLifes = Math.Max(0, currentLifes - enemy.Data.DamageToLifes);
            OnLivesChanged?.Invoke(this);
        }
    }
}
