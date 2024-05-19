using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 35; // Varsay�lan hasar de�eri
    public bool isShotgunBullet = false; // Shotgun mermisi olup olmad���n� belirten bayrak
    public float decayRate = 1f; // Shotgun mermisinin hasar�n�n azalmas� h�z�
    public float minDamage = 5f; // Shotgun mermisinin d��ebilece�i minimum hasar de�eri


    void Update()
    {
        if (isShotgunBullet)
        {
            // Hasar� zamanla azalt
            damage -= Mathf.RoundToInt(decayRate * Time.deltaTime);

            // Hasar�n minimum de�erden daha d���k olmamas�n� sa�la
            if (damage < minDamage)
            {
                damage = Mathf.RoundToInt(minDamage);
            }
        }
    }
}
