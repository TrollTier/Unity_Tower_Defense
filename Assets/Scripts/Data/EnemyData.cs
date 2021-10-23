using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField]
        private float health = 100f;
        public float Health => health;

        [SerializeField]
        private int damageToLifes = 1;
        public int DamageToLifes => damageToLifes;

        [SerializeField]
        private int moneyOnDeath = 1;
        public int MoneyOnDeath => moneyOnDeath;

        [SerializeField]
        private string monsterName = string.Empty;
        public string MonsterName => monsterName;
    }
}
