using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public int RotateSpeed;
    public AudioSource CollectSound;
    public GameObject ThisHeart;

    void Update()
    {
        RotateSpeed = 2;
        transform.Rotate(0, RotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (HealthMonitor.HealthValue == 300)
        {
            //stuff
        }
        if (HealthMonitor.HealthValue > 280 && HealthMonitor.HealthValue < 300)
        {
            CollectSound.Play();
            HealthMonitor.HealthValue = 300;
            ThisHeart.SetActive(false);
        }
        if (HealthMonitor.HealthValue <= 280)
        {
            CollectSound.Play();
            HealthMonitor.HealthValue += 25;
            ThisHeart.SetActive(false);
        }
    }
}
