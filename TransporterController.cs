using UnityEngine;

public class TransporterController : MonoBehaviour
{
    public GameObject transporter;
    public float pickupDistance = 5f;
    public Transform currentPassenger;
    public Transform currentDestination;
    public bool hasPassenger = false;
    public int successfulCourses = 0;
    public float rotationSpeed = 5f; // Vitesse de rotation du transporteur

    public void PickUpPassenger()
    {
        if (currentPassenger != null && Vector3.Distance(transform.position, currentPassenger.position) < pickupDistance)
        {
            currentPassenger.SetParent(transform); // Set passenger as child of transporter
            currentPassenger.localPosition = new Vector3(0, 2, 0); // Adjust passenger's local position
            hasPassenger = true;
        }
    }

    public void DropOffPassenger()
    {
        if (hasPassenger && Vector3.Distance(transform.position, currentDestination.position) < pickupDistance)
        {
            currentPassenger.SetParent(null); // Unparent the passenger
            Destroy(currentPassenger.gameObject); // Destroy the passenger
            currentPassenger = null;
            hasPassenger = false;
            currentDestination = null; // Reset destination
            successfulCourses++;
        }
    }

    void Update()
    {
        Vector3 targetPosition = hasPassenger ? currentDestination.position : currentPassenger.position;

        // Déplacer le transporteur vers la cible
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);

        // Calculer la direction vers laquelle le transporteur devrait regarder
        Vector3 direction = (targetPosition - transform.position).normalized;

        if (direction.magnitude > 0.1f) // Éviter de faire une rotation quand la cible est très proche
        {
            // Calculer la rotation nécessaire pour regarder vers la cible
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Appliquer progressivement cette rotation au transporteur
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (!hasPassenger && currentPassenger != null)
        {
            PickUpPassenger();
        }
        else if (hasPassenger)
        {
            DropOffPassenger();
        }
    }
}
