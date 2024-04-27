using UnityEngine;

public class ShipControllerv2 : MonoBehaviour
{
    public float edgeThreshold = 10.0f;
    public Camera mainCamera; // Assignez cela dans l'inspecteur ou trouvez-le via script

    private void Start()
    {
        // Si la caméra n'est pas assignée, trouvez la caméra principale
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToEdge = GetDirectionToScreenEdge();
        if (directionToEdge != Vector3.zero)
        {
            OrientTowards(directionToEdge);
            OrientCameraTowards(directionToEdge);
        }
    }

    Vector3 GetDirectionToScreenEdge()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - mainCamera.transform.position.z));
        Vector3 directionToEdge = Vector3.zero;

        // Check for horizontal edges
        if (mousePosition.x <= edgeThreshold)
        {
            directionToEdge = (mouseWorldPosition - transform.position).normalized;
        }
        else if (mousePosition.x >= Screen.width - edgeThreshold)
        {
            directionToEdge = (mouseWorldPosition - transform.position).normalized;
        }

        // Check for vertical edges
        if (mousePosition.y <= edgeThreshold)
        {
            directionToEdge = (mouseWorldPosition - transform.position).normalized;
        }
        else if (mousePosition.y >= Screen.height - edgeThreshold)
        {
            directionToEdge = (mouseWorldPosition - transform.position).normalized;
        }

        return directionToEdge;
    }

    void OrientTowards(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
    }

    void OrientCameraTowards(Vector3 direction)
    {
        // This rotates the camera to look at the point where the spaceship is looking
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        // Adjust as necessary for your camera's default orientation
        mainCamera.transform.rotation = Quaternion.RotateTowards(mainCamera.transform.rotation, targetRotation, 360 * Time.deltaTime);
    }
}
