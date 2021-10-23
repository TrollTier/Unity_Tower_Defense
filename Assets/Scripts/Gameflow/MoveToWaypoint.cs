using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Gameflow
{
    public class MoveToWaypoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var waypoint = other.GetComponent<Waypoint>();

            if (waypoint?.NextWaypoint == null)
            {
                return;
            }

            var navAgent = GetComponent<NavMeshAgent>();

            if (navAgent != null)
            {
                navAgent.SetDestination(waypoint.NextWaypoint.position);
            }
        }
    }
}
