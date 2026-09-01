using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemyBoss : MonoBehaviour
{
    public int EnemyHealth = 35;
    public GameObject TheSpider;
    public int SpiderStatus;
    public int BaseXP = 650;
    public int CalculatedXP;
    public SpiderBossAI SpiderAIScript;
    public static int GlobalSpider;
    public GameObject OldNPC;
    public GameObject NewNPC;
    public SpiderBossAttack SpiderAttackScript;

    void Start()
    {
        SpiderAIScript = GetComponent<SpiderBossAI>();
        SpiderAttackScript = GetComponent<SpiderBossAttack>();
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
        SpiderAttackScript.enabled = false;
        SpiderStatus = 6;
        CalculatedXP = BaseXP * GlobalLevel.CurrentLevel;
        GlobalExp.CurrentExp += CalculatedXP;
        yield return new WaitForSeconds(0.5f);
        TheSpider.GetComponent<Animation>().Play("SpiderBossDeath");
        yield return new WaitForSeconds(1.5f);
        TheSpider.GetComponent<Animation>().enabled = false;
        OldNPC.SetActive(false);
        NewNPC.SetActive(true);
        QuestManager.SubQuestNumber = 4;
    }
}
