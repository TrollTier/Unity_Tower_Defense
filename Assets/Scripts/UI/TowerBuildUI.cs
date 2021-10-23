using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class TowerBuildUI : MonoBehaviour
    {
        [SerializeField]
        private Button startBuildingButton;

        public TowerBuildData towerData;

        private void Start()
        {
            startBuildingButton.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            Events.SendTowerBuildingRequested(towerData);
        }
    }
}
