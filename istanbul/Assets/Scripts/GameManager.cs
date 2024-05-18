using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public float gameTime = 300f; // Oyun süresi (saniye cinsinden)
    public int playerDamage = 35; // Oyuncunun atýþýnýn verdiði hasar
    public int enemyHealth = 100; // Düþmanýn caný
    private float currentTime;

    void Start()
    {
        currentTime = gameTime;
        UpdateTimerDisplay();
        InvokeRepeating("UpdateGameTime", 1f, 1f); // Her saniyede zamaný güncelle
    }

    void UpdateGameTime()
    {
        currentTime -= 1f;

        // Zamaný güncelle
        UpdateTimerDisplay();

        // Oyun süresi bittiðinde oyunu durdur
        if (currentTime <= 0f)
        {
            EndGame();
        }
    }

    void UpdateTimerDisplay()
    {
        // Zamaný dakika ve saniye cinsine dönüþtür
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((currentTime * 100) % 100);

        // Dijital saat metnini güncelle
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void PlayerHitByBullet()
    {
        // Player düþmanýn mermisiyle vurulduðunda 15 saniye eksilir
        currentTime -= 15f;
        UpdateTimerDisplay();
    }

    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd; // Belirli bir süreyi toplam oyun süresine ekle
        UpdateTimerDisplay(); // Dijital saati güncelle
    }

    public void EnemyDestroyed()
    {
        // Düþman yok edildiðinde 15 saniye eklenir
        currentTime += 15f;
        UpdateTimerDisplay();
    }

    void EndGame()
    {
        // Oyunu durdur veya baþka bir iþlem yap
        Debug.Log("Oyun bitti!");
        // Burada oyunu durdurabilir veya baþka bir þey yapabilirsiniz
    }
}
