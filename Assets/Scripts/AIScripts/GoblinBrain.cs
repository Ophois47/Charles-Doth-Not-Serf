using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBrain : MonoBehaviour
{
    public int EnemyHealth = 30;
    public GameObject TheGoblin;
    public int GoblinStatus;
    public int BaseXP = 50;
    public int CalculatedXP;
    public GoblinAI GoblinAIScript;
    public static int GlobalGoblin;
    public AudioSource GoblinDeathSound;

    void Start()
    {
        GoblinAIScript = GetComponent<GoblinAI>();
    }

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        GlobalGoblin = GoblinStatus;
        if (EnemyHealth <= 0)
        {
            if (GoblinStatus == 0)
            {
                StartCoroutine(DeathGoblin());
            }
        }
    }

    IEnumerator DeathGoblin()
    {
        GoblinAIScript.enabled = false;
        GoblinStatus = 6;
        CalculatedXP = BaseXP * GlobalLevel.CurrentLevel;
        GlobalExp.CurrentExp += CalculatedXP;
        yield return new WaitForSeconds(0.3f);
        GoblinDeathSound.Play();
        TheGoblin.GetComponent<Animation>().Play("death");
    }
}
