using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 15;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public int DealingDamage;
    public AudioSource GoblinSound1;
    public AudioSource GoblinChillSound;
    public AudioSource GoblinIdleSound;

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedRange)
            {
                EnemySpeed = 0.04f;
                if (AttackTrigger == 0)
                {
                    TheEnemy.GetComponent<Animation>().Play("run");
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
                TheEnemy.GetComponent<Animation>().Play("attack1");
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
        GoblinIdleSound.Play();
        if (GoblinBrain.GlobalGoblin != 6)
        {
            HealthMonitor.HealthValue -= 12;
        }
        yield return new WaitForSeconds(0.4f);
        DealingDamage = 0;
    }
}
