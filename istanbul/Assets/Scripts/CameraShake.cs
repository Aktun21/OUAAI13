using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform; // Kamera transformu
    public float shakeDuration = 0.1f; // Sallanma s�resi
    public float shakeAmount = 0.1f; // Sallanma miktar�

    private Vector3 originalPos; // Kameran�n orijinal pozisyonu

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            // Kameray� salla
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            // Sallanma s�resi doldu�unda kameray� orijinal pozisyonuna geri getir
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void Shake()
    {
        originalPos = camTransform.localPosition;
        shakeDuration = 0.1f;
    }
}
