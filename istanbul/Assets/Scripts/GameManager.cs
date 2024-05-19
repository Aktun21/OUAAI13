using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public float gameTime = 300f; // Oyun s�resi (saniye cinsinden)
    public int playerDamage = 35; // Oyuncunun at���n�n verdi�i hasar
    public int enemyHealth = 100; // D��man�n can�
    private float currentTime;

    void Start()
    {
        currentTime = gameTime;
        UpdateTimerDisplay();
        InvokeRepeating("UpdateGameTime", 1f, 1f); // Her saniyede zaman� g�ncelle
    }

    void UpdateGameTime()
    {
        currentTime -= 1f;

        // Zaman� g�ncelle
        UpdateTimerDisplay();

        // Oyun s�resi bitti�inde oyunu durdur
        if (currentTime <= 0f)
        {
            EndGame();
        }
    }

    void UpdateTimerDisplay()
    {
        // Zaman� dakika ve saniye cinsine d�n��t�r
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((currentTime * 100) % 100);

        // Dijital saat metnini g�ncelle
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void PlayerHitByBullet()
    {
        // Player d��man�n mermisiyle vuruldu�unda 15 saniye eksilir
        currentTime -= 15f;
        UpdateTimerDisplay();
    }

    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd; // Belirli bir s�reyi toplam oyun s�resine ekle
        UpdateTimerDisplay(); // Dijital saati g�ncelle
    }

    public void EnemyDestroyed()
    {
        // D��man yok edildi�inde 15 saniye eklenir
        currentTime += 15f;
        UpdateTimerDisplay();
    }

    void EndGame()
    {
        // Oyunu durdur veya ba�ka bir i�lem yap
        Debug.Log("Oyun bitti!");
        // Burada oyunu durdurabilir veya ba�ka bir �ey yapabilirsiniz
    }
}
