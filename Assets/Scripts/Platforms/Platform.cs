using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach (PlatformSegment platformSegment in platformSegments)
        {
            platformSegment.Bounce(_force, transform.position, _radius);
        }
    }
}
