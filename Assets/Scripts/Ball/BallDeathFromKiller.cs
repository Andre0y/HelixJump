using UnityEngine;

public class BallDeathFromKiller : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            Destroy(other.gameObject);
        }
    }
}
