using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float lifetime = 7f; // Mermi �mr� (saniye cinsinden)

    void Start()
    {
        // Belirlenen �m�r s�resi sonunda mermiyi yok et
        Destroy(gameObject, lifetime);
    }
}
