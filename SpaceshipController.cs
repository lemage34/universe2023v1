using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    public float acceleration = 100f; 
    public float deceleration = 100f; // Vitesse de décélération
    private float currentSpeed = 0f; 

    public bool hasPassenger = false;
    private Transform passenger;

    public void PickUpPassenger(Transform _passenger)
    {
        passenger = _passenger;
        passenger.SetParent(transform); // Set the spaceship as the passenger's parent
        passenger.localPosition = Vector3.zero; // Set passenger's position relative to the spaceship
        hasPassenger = true;
    }

    public void DropOffPassenger()
    {
        passenger.SetParent(null); // Detach the passenger from the spaceship
        hasPassenger = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotation du vaisseau
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.left, verticalInput * rotationSpeed * Time.deltaTime, Space.World);

        // Accélération avec "Control Gauche"
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        // Décélération avec "W"
        if (Input.GetKey(KeyCode.RightControl))
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }

        // Stopper le vaisseau avec "X"
        if (Input.GetKey(KeyCode.X))
        {
            currentSpeed = 0;
        }

        // Déplacement du vaisseau
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
    }
}
