using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(target.position);
        }
    }
}
