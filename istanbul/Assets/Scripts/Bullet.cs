using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 35; // Varsayýlan hasar deðeri
    public bool isShotgunBullet = false; // Shotgun mermisi olup olmadýðýný belirten bayrak
    public float decayRate = 1f; // Shotgun mermisinin hasarýnýn azalmasý hýzý
    public float minDamage = 5f; // Shotgun mermisinin düþebileceði minimum hasar deðeri


    void Update()
    {
        if (isShotgunBullet)
        {
            // Hasarý zamanla azalt
            damage -= Mathf.RoundToInt(decayRate * Time.deltaTime);

            // Hasarýn minimum deðerden daha düþük olmamasýný saðla
            if (damage < minDamage)
            {
                damage = Mathf.RoundToInt(minDamage);
            }
        }
    }
}
