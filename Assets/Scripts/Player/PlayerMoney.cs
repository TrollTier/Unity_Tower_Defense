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
        }

        private void OnDestroy()
        {
            Events.EnemyDied -= HandleEnemyDied;
        }

        private void HandleEnemyDied(Enemy enemy)
        {
            currentMoney += enemy.Data.MoneyOnDeath;

            OnAmountChanged?.Invoke(this);
        }
    }
}
