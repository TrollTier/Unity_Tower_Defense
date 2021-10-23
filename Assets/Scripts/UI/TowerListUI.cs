using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TowerListUI : MonoBehaviour
    {
        [SerializeField]
        private RectTransform content;

        [SerializeField]
        private GameObject itemPrefab;

        [SerializeField]
        private TowerBuildData[] towers;


        private void Start()
        {
            for (int i = 0; i < towers.Length; i++)
            {
                var tower = towers[i];

                var item = GameObject.Instantiate(itemPrefab);
                var ui = item.GetComponent<TowerBuildUI>();

                if (ui)
                {
                    ui.towerData = tower;
                }

                item.transform.SetParent(content);
            }
        }
    }
}
