using UnityEngine;

public class RotateAroundStar : MonoBehaviour
{
    public float rotationSpeed = 3f;
    private Transform starTransform;

    private void Start()
    {
        // Assumer que l'étoile est le parent de la planète dans la hiérarchie
        starTransform = transform.parent;
    }

    private void Update()
    {
        // Faire tourner la planète autour de l'étoile
        transform.RotateAround(starTransform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
