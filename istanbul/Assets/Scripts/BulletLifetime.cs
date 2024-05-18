using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float lifetime = 7f; // Mermi ömrü (saniye cinsinden)

    void Start()
    {
        // Belirlenen ömür süresi sonunda mermiyi yok et
        Destroy(gameObject, lifetime);
    }
}
