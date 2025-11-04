using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    [SerializeField] private float decreaseRate = 0.05f;
    [SerializeField] private float hitIncrease = 0.1f;
    [SerializeField] private float missDecrease = 0.1f;
    [SerializeField] private BarManager barManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
