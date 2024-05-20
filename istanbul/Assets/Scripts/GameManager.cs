using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public float gameTime = 50f; // Oyun s�resi (saniye cinsinden)
    private float currentTime;
    public AudioClip alertSound; // Uyar� sesi
    public AudioSource audioSource; // Ses kayna��
    public float countdownThreshold = 30f; // K�rm�z�ya ge�i� e�i�i (saniye cinsinden)
    public float criticalTime = 5f; // Kritik zaman e�i�i (saniye cinsinden)
    public float textGrowScale = 1.5f; // Metnin b�y�me �l�e�i
    public float fastTimeMultiplier = 2f; // Zaman h�zlanma �arpan�

    private Color defaultTextColor; // Metnin varsay�lan rengi
    private bool isFastTime = false;

    void Start()
    {
        currentTime = gameTime;
        defaultTextColor = timerText.color; // Varsay�lan metin rengini kaydet
        UpdateTimerDisplay();
        InvokeRepeating("UpdateGameTime", 1f, 1f); // Her saniyede zaman� g�ncelle
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

        // Zaman� g�ncelle
        UpdateTimerDisplay();

        // Zaman kritik e�i�in alt�ndaysa ses �al
        if (currentTime <= criticalTime && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(alertSound);
        }

        // Zaman s�f�r oldu�unda sahneyi ba�tan y�kle
        if (currentTime <= 0f)
        {
            SceneManager.LoadScene(2);
        }

        // Zaman kritik e�i�in �st�ndeyse ve ses �al�yorsa, sesi durdur
        if (currentTime > criticalTime && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void UpdateTimerDisplay()
    {
        // Zaman� dakika ve saniye cinsine d�n��t�r
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        // Dijital saat metnini g�ncelle
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Zaman belirli bir e�i�in alt�na d��t���nde metni k�rm�z�ya d�n��t�r ve b�y�t
        if (currentTime <= countdownThreshold)
        {
            timerText.color = Color.red;
            timerText.transform.localScale = Vector3.one * textGrowScale;
        }
        else
        {
            // Zaman e�i�in �zerindeyse, metni varsay�lan rengine ve �l�e�e geri d�nd�r
            timerText.color = defaultTextColor;
            timerText.transform.localScale = Vector3.one * 3.12f;
        }

        // Zaman 00:00 oldu�unda sahneyi ba�tan y�kle
        if (currentTime <= 0f)
        {

            SceneManager.LoadScene(2);
        }
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

    void ReloadScene()
    {
        // Sahneyi ba�tan y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void EndGame()
    {
        // Oyunu durdur veya ba�ka bir i�lem yap
        Debug.Log("Oyun bitti!");
        // Burada oyunu durdurabilir veya ba�ka bir �ey yapabilirsiniz
    }
}
