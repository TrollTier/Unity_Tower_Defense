using Assets.Scripts;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform muzzlePosition;

    [SerializeField]
    private float projectilesPerSecond = 1f;

    [SerializeField]
    private float projectileSpeed = 100f;

    private float secondsSinceLastShot = 0f;
    private float secondsPerProjectile = 1;

    private void Start()
    {
        secondsPerProjectile = 1f / projectilesPerSecond;
    }


    void Update()
    {
        secondsSinceLastShot += Time.deltaTime;

        var target = TowerAIData.GetClosestEnemy(transform.position);
        
        if (target == null)
        {
            return;
        }

        if (secondsSinceLastShot >= secondsPerProjectile && target != null)
        {
            var dir = (target.transform.position - muzzlePosition.position).normalized;

            var projectile = GameObject.Instantiate(projectilePrefab);
            projectile.GetComponent<Transform>().position = muzzlePosition.position;
            projectile.GetComponent<Transform>().LookAt(target.transform);
            projectile.GetComponent<Rigidbody>().velocity = dir * projectileSpeed;

            secondsSinceLastShot = 0;
        }
    }
}
