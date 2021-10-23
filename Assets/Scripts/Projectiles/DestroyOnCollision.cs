using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyOnCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(this.gameObject);
        }
    }
}
