using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public float gameTime = 50f; // Oyun süresi (saniye cinsinden)
    private float currentTime;
    public AudioClip alertSound; // Uyarý sesi
    public AudioSource audioSource; // Ses kaynaðý
    public float countdownThreshold = 30f; // Kýrmýzýya geçiþ eþiði (saniye cinsinden)
    public float criticalTime = 5f; // Kritik zaman eþiði (saniye cinsinden)
    public float textGrowScale = 1.5f; // Metnin büyüme ölçeði
    public float fastTimeMultiplier = 2f; // Zaman hýzlanma çarpaný

    private Color defaultTextColor; // Metnin varsayýlan rengi
    private bool isFastTime = false;

    void Start()
    {
        currentTime = gameTime;
        defaultTextColor = timerText.color; // Varsayýlan metin rengini kaydet
        UpdateTimerDisplay();
        InvokeRepeating("UpdateGameTime", 1f, 1f); // Her saniyede zamaný güncelle
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFastTime = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFastTime = false;
        }
    }

    void UpdateGameTime()
    {
        float timeDecrement = isFastTime ? fastTimeMultiplier : 1f;
        currentTime -= timeDecrement;

        // Zamaný güncelle
        UpdateTimerDisplay();

        // Zaman kritik eþiðin altýndaysa ses çal
        if (currentTime <= criticalTime && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(alertSound);
        }

        // Zaman sýfýr olduðunda sahneyi baþtan yükle
        if (currentTime <= 0f)
        {
            SceneManager.LoadScene(2);
        }

        // Zaman kritik eþiðin üstündeyse ve ses çalýyorsa, sesi durdur
        if (currentTime > criticalTime && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void UpdateTimerDisplay()
    {
        // Zamaný dakika ve saniye cinsine dönüþtür
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        // Dijital saat metnini güncelle
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Zaman belirli bir eþiðin altýna düþtüðünde metni kýrmýzýya dönüþtür ve büyüt
        if (currentTime <= countdownThreshold)
        {
            timerText.color = Color.red;
            timerText.transform.localScale = Vector3.one * textGrowScale;
        }
        else
        {
            // Zaman eþiðin üzerindeyse, metni varsayýlan rengine ve ölçeðe geri döndür
            timerText.color = defaultTextColor;
            timerText.transform.localScale = Vector3.one * 3.12f;
        }

        // Zaman 00:00 olduðunda sahneyi baþtan yükle
        if (currentTime <= 0f)
        {

            SceneManager.LoadScene(2);
        }
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

    void ReloadScene()
    {
        // Sahneyi baþtan yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void EndGame()
    {
        // Oyunu durdur veya baþka bir iþlem yap
        Debug.Log("Oyun bitti!");
        // Burada oyunu durdurabilir veya baþka bir þey yapabilirsiniz
    }
}
