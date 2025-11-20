using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    [SerializeField] private float decreaseRate = 0.05f;
    [SerializeField] private float hitIncrease = 0.1f;
    [SerializeField] private float missDecrease = 0.1f;
    [SerializeField] private BarManager barManager;

    private void Start()
    {
        barManager.percent = health;
    }

    private void IncrementHealth(float increment)
    {
        if (GameGameMode.gameMode == GameMode.FREESTYLE)
        {
            return;
        }
        
        health = Mathf.Clamp(health + increment, 0f, 1f);
        barManager.percent = health;
    }
    
    public void Hit()
    {
        IncrementHealth(hitIncrease);
    }
    
    public void Miss()
    {
        IncrementHealth(-missDecrease);
    }

    private void Update()
    {
        IncrementHealth(-decreaseRate * Time.deltaTime);
    }
}
