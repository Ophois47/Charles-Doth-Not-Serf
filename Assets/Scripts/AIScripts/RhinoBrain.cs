using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoBrain : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject TheRhino;
    public int RhinoStatus;
    public int BaseXP = 5;
    public int CalculatedXP;
    public RhinoAI RhinoAIScript;
    public static int GlobalRhino;
    public AudioSource RhinoDeathSound;

    void Start()
    {
        RhinoAIScript = GetComponent<RhinoAI>();
    }

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        GlobalRhino = RhinoStatus;
        if (EnemyHealth <= 0)
        {
            if (RhinoStatus == 0)
            {
                StartCoroutine(DeathRhino());
            }
        }
    }

    IEnumerator DeathRhino()
    {
        RhinoAIScript.enabled = false;
        RhinoStatus = 6;
        CalculatedXP = BaseXP * GlobalLevel.CurrentLevel;
        GlobalExp.CurrentExp += CalculatedXP;
        yield return new WaitForSeconds(0.3f);
        RhinoDeathSound.Play();
        TheRhino.GetComponent<Animation>().Play("Dead");
    }
}
