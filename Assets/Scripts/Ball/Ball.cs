using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            platformSegment.GetComponentInParent<Platform>().Break(); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out FinishPlatform finishPlatform))
        {
            //Application.Quit();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Time.timeScale = 0;
        }
    }
}
