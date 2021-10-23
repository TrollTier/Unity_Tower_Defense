using UnityEngine;

namespace Assets.Scripts.Gameflow
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField]
        // Can be null
        private Transform nextWaypoint;
        public Transform NextWaypoint => nextWaypoint;
    }
}
