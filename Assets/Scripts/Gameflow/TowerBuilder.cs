using Assets.Scripts.Data;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Assets.Scripts.Gameflow
{
    public class TowerBuilder : MonoBehaviour
    {
        private GameObject currentTower;
        private TowerBuildData currentData;

        private GameObject terrain;

        private void Start()
        {
            terrain = GameObject.FindWithTag("Terrain");

            Events.TowerBuildingRequested += HandleTowerBuildingRequested;
        }

        private void OnDestroy()
        {
            Events.TowerBuildingRequested -= HandleTowerBuildingRequested;
        }

        private void HandleTowerBuildingRequested(TowerBuildData towerBuildData)
        {
            if (currentTower != null)
            {
                return;
            }

            currentData = towerBuildData;
            currentTower = Instantiate(towerBuildData.Prefab);
        }

        private void Update()
        {
            if (currentTower == null)
            {
                return;
            }

            var hit = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.tag == "Terrain")
                {
                    currentTower.transform.position = hit[i].point;
                }
            }

            if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
            {
                currentTower = null;

                Events.SendTowerBuilt(currentData);

                currentData = null;
            }
        }
    }
}
