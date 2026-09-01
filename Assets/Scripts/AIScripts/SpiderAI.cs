using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 20;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public int DealingDamage;
    public AudioSource SpiderIdleSound;
    public AudioSource SpiderAttackSound;

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedRange)
            {
                EnemySpeed = 0.05f;
                if (AttackTrigger == 0)
                {
                    TheEnemy.GetComponent<Animation>().Play("walk");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            }
            else
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("idle");
            }
        }
        if (AttackTrigger == 1)
        {
            if (DealingDamage == 0)
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("attack");
                StartCoroutine(TakingDamage());
            }
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = 1;
    }

    void OnTriggerExit()
    {
        AttackTrigger = 0;
    }

    IEnumerator TakingDamage()
    {
        DealingDamage = 1;
        yield return new WaitForSeconds(0.5f);
        SpiderAttackSound.Play();
        if (SpiderEnemy.GlobalSpider != 6)
        {
            HealthMonitor.HealthValue -= 10;
        }
        yield return new WaitForSeconds(0.4f);
        DealingDamage = 0;
    }
}
