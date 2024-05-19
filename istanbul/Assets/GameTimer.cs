using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text gameTimerText; // UI Text bileþeni referansý
    private float elapsedTime = 0f; // Geçen zaman

    void Start()
    {
        // Oyun baþladýðýnda zamanlayýcýyý sýfýrlayýn
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    void Update()
    {
        // Geçen zamaný güncelle
        elapsedTime += Time.deltaTime;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        // Zamaný dakika ve saniye cinsine dönüþtür
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Dijital saat metnini güncelle
        gameTimerText.text = string.Format("{0:00}:{1:00}" ,minutes, seconds);
    }
}
