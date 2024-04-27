using UnityEngine;

public class ToggleUIObjects : MonoBehaviour
{
    public GameObject[] uiObjectsToToggle; // Array to hold references to the UI objects you want to toggle

    void Update()
    {
        // Check if the "E" key was pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Loop through each GameObject in the array and toggle its active state
            foreach (GameObject uiObject in uiObjectsToToggle)
            {
                uiObject.SetActive(!uiObject.activeSelf);
            }
        }
    }
}
