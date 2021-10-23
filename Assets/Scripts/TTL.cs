using UnityEngine;

public class TTL : MonoBehaviour
{
    [SerializeField]
    private float secondsToLive = 10f;

    private float secondsAlive = 0f;

    // Update is called once per frame
    void Update()
    {
        secondsAlive += Time.deltaTime;

        if (secondsAlive > secondsToLive)
        {
            Destroy(gameObject);
        }
    }
}
