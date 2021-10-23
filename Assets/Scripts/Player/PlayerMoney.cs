using Assets.Scripts.Data;
using Assets.Scripts.Gameflow;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMoney : MonoBehaviour
    {
        public delegate void PlayerMoneyHandler(PlayerMoney money);

        public event PlayerMoneyHandler OnAmountChanged;

        [SerializeField]
        private int currentMoney = 1000;

        public int CurrentMoney => currentMoney;

        private void Start()
        {
            Events.EnemyDied += HandleEnemyDied;
            Events.TowerBuilt += HandleTowerBuilt;
        }

        private void OnDestroy()
        {
            Events.EnemyDied -= HandleEnemyDied;
            Events.TowerBuilt -= HandleTowerBuilt;
        }

        private void HandleEnemyDied(Enemy enemy)
        {
            currentMoney += enemy.Data.MoneyOnDeath;

            OnAmountChanged?.Invoke(this);
        }

        private void HandleTowerBuilt(TowerBuildData data)
        {
            currentMoney -= data.BaseCosts;
            OnAmountChanged?.Invoke(this);
        }
    }
}
