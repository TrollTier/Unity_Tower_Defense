using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Gameflow
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private int lifesOnStart = 50;

        private int currentLifes = 50;

        private void Start()
        {
            currentLifes = lifesOnStart;
        }
    }
}
