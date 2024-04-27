using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public static PlayerMover instance;

    public float speed = 5f;
    public float rotationSpeed = 2f;
    public float colorTransitionSpeed = 1f; // Vitesse de la transition de couleur
    public float stopDistance = 50f;
    public AudioSource audioSource;
    public AudioClip movingSound;
    public Camera mainCamera;
    public Color movingBackgroundColor = new Color(0, 0, 0.2f, 1);
    public Color defaultBackgroundColor = Color.black;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveToStar(Vector3 starPosition)
    {
        StopAllCoroutines();
        StartCoroutine(MoveTowardsTarget(starPosition));
        audioSource.clip = movingSound;
        audioSource.priority = 0;
        audioSource.Play();
    }

    System.Collections.IEnumerator MoveTowardsTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        Vector3 stoppingPoint = target - directionToTarget * stopDistance;
        float journeyLength = Vector3.Distance(transform.position, stoppingPoint);

        while (Vector3.Distance(transform.position, stoppingPoint) > 0.1f)
        {
            float distanceCovered = journeyLength - Vector3.Distance(transform.position, stoppingPoint);
            float fractionOfJourney = distanceCovered / journeyLength;

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, stoppingPoint, speed * Time.deltaTime);

            // Interpoler la couleur de fond
            mainCamera.backgroundColor = Color.Lerp(defaultBackgroundColor, movingBackgroundColor, fractionOfJourney * colorTransitionSpeed);

            yield return null;
        }

        // Assurer que la couleur redevient noir à la fin du mouvement
        while (mainCamera.backgroundColor != defaultBackgroundColor)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, defaultBackgroundColor, colorTransitionSpeed * Time.deltaTime);
            yield return null;
        }

        audioSource.Stop();
    }
}
