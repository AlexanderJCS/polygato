using UnityEngine;

public class BarManager : MonoBehaviour
{
    [Range (0f, 1f)]
    public float percent;

    private GameObject scaler;
    
    private void Start()
    {
        scaler = GameObject.Find("HealthScaler");
    }
    
    private void Update()
    {
        scaler.transform.localScale = new Vector3(percent, 1f, 1f);
    }
}
