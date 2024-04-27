using UnityEngine;

public class DistanceDisplay : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = Camera.main; // Assurez-vous que votre caméra est marquée comme Main Camera
    }

    private void Update()
    {
        CheckDistanceToObjectUnderMouse();
    }

    void CheckDistanceToObjectUnderMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            float distance = Vector3.Distance(cam.transform.position, hit.transform.position);
            Debug.Log("Distance to object: " + distance + " units.");
        }
    }
}
