using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
        if (collision.gameObject.TryGetComponent(out Killer killer))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        if (collision.gameObject.TryGetComponent(out FinishPlatform finishPlatform))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
