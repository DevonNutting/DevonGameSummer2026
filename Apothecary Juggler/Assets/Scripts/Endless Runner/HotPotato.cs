using UnityEngine;

public class HotPotato : MonoBehaviour
{
    public float maxTimer = 10f;
    public float remainingTime = 0f;
    public PotatoVisual potatoVisual;

    public void Initialize(float remianingTimer)
    {
        // Called whenever a player gets the hot potato
        remainingTime = remianingTimer;
    }

    private void Awake()
    {
        // Set the timer of the potato
        remainingTime = maxTimer;
        // Initialize the potato visual
        potatoVisual = GetComponentInChildren<PotatoVisual>(true);
        // Disable the potato visual
        TogglePotatoVisual(true);
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("BOOOM!");
        }
    } 

    private void TogglePotatoVisual(bool flag)
    {
        // Turn the potato visual on or off based on the given flag
        potatoVisual.gameObject.SetActive(flag);
    }

    private void OnDestroy()
    {
        // Toggle off the potato visual
        TogglePotatoVisual(false);
    }
}
