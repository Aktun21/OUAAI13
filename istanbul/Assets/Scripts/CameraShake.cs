using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform; // Kamera transformu
    public float shakeDuration = 0.1f; // Sallanma süresi
    public float shakeAmount = 0.1f; // Sallanma miktarý

    private Vector3 originalPos; // Kameranýn orijinal pozisyonu

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
            // Kamerayý salla
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            // Sallanma süresi dolduðunda kamerayý orijinal pozisyonuna geri getir
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
