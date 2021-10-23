using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tower")]
    public class TowerBuildData : ScriptableObject
    {
        [SerializeField]
        private int baseCosts = 200;
        public int BaseCosts => baseCosts;

        [SerializeField]
        private GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField]
        private Texture2D avatar;
        public Texture2D Avatar => avatar;
    }
}
