using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    public void Heal(int amount)
    {
        health.TakeDamage(-amount); // Saðlýk eklemek için negatif hasar
    }
}
