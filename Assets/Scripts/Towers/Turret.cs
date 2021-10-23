using Assets.Scripts;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform turret;

    void Update()
    {
        var enemy = TowerAIData.GetClosestEnemy(transform.position);

        if (enemy == null)
        {
            return;
        }

        turret.LookAt(enemy.transform);
    }
}
