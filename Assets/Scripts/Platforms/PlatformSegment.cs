using UnityEngine;

public class PlatformSegment : MonoBehaviour
{
    public void Bounce(float force, Vector3 center, float radius)
    {
        if(TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, center, radius);
        }
    }
}
