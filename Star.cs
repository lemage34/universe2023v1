using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] public int temperature;
    
    public int Temperature
    {
        get { return temperature; }
        set { temperature = value; }
    }
    
    private void Start()
    {
        //Debug.Log("Star temperature: " + temperature);
    }
}
