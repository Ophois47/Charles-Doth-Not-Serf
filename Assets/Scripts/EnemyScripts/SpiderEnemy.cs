using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    public int EnemyHealth = 10;
    public GameObject TheSpider;
    public int SpiderStatus;
    public int BaseXP = 10;
    public int CalculatedXP;
    public SpiderAI SpiderAIScript;
    public static int GlobalSpider;
    public AudioSource SpiderDeathSound;

    void Start()
    {
        SpiderAIScript = GetComponent<SpiderAI>();
    }

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        GlobalSpider = SpiderStatus;
        if (EnemyHealth <= 0)
        {
            if (SpiderStatus == 0)
            {
                StartCoroutine(DeathSpider());
            }
        }
    }

    IEnumerator DeathSpider()
    {
        SpiderAIScript.enabled = false;
        SpiderStatus = 6;
        CalculatedXP = BaseXP * GlobalLevel.CurrentLevel;
        GlobalExp.CurrentExp += CalculatedXP;
        yield return new WaitForSeconds(0.3f);
        SpiderDeathSound.Play();
        TheSpider.GetComponent<Animation>().Play("die");
    }
}
