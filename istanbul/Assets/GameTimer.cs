using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text gameTimerText; // UI Text bile�eni referans�
    private float elapsedTime = 0f; // Ge�en zaman

    void Start()
    {
        // Oyun ba�lad���nda zamanlay�c�y� s�f�rlay�n
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    void Update()
    {
        // Ge�en zaman� g�ncelle
        elapsedTime += Time.deltaTime;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        // Zaman� dakika ve saniye cinsine d�n��t�r
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Dijital saat metnini g�ncelle
        gameTimerText.text = string.Format("{0:00}:{1:00}" ,minutes, seconds);
    }
}
