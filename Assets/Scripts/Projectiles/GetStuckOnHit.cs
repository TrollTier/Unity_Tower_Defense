using UnityEngine;

namespace Assets.Scripts
{
    public class GetStuckOnHit : MonoBehaviour
    {
        [SerializeField]
        private float stuckDurationSeconds = 5f;

        private bool isStuck = false;
        private float stuckSinceSeconds = 0f;

        private void OnCollisionEnter(Collision collision)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<BoxCollider>().enabled = false;

            transform.position = collision.contacts[0].point;
            transform.SetParent(collision.transform);

            isStuck = true;
        }

        private void Update()
        {
            stuckSinceSeconds += Time.deltaTime * (isStuck ? 1 : 0);

            if (isStuck && stuckSinceSeconds >= stuckDurationSeconds)
                GameObject.Destroy(this.gameObject);
        }
    }
}
