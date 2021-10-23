using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageOnHit : MonoBehaviour
    {
        [SerializeField]
        private float damage = 10f;

        private void OnCollisionEnter(Collision collision)
        {
            var health = collision.collider.GetComponent<Health>();

            if (health != null)
            {
                health.AddDamage(damage);
            }
        }
    }
}
