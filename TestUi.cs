using UnityEngine;
using UnityEngine.UI;

public class TestUi : MonoBehaviour
{
    public Text testText;

    void Update()
    {
        //Debug.Log("Y Position: " + transform.position.y.ToString());
        //Debug.Log("Z Position: " + transform.position.z.ToString());
        
        testText.text = "X Position: " + transform.position.x.ToString() +
                        "Y Position: " + transform.position.y.ToString() +
                        "Z Position: " + transform.position.z.ToString();
    }
}
