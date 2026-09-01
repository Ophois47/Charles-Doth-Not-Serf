using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 15;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public int DealingDamage;
    public AudioSource RhinoAttackSound;
    public AudioSource RhinoIdleSound;

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedRange)
            {
                EnemySpeed = 0.08f;
                if (AttackTrigger == 0)
                {
                    TheEnemy.GetComponent<Animation>().Play("Walk");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            }
            else
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("Eats");
            }
        }
        if (AttackTrigger == 1)
        {
            if (DealingDamage == 0)
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("Attack");
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
        yield return new WaitForSeconds(0.9f);
        RhinoAttackSound.Play();
        if (RhinoBrain.GlobalRhino != 6)
        {
            HealthMonitor.HealthValue -= 25;
        }
        yield return new WaitForSeconds(0.8f);
        DealingDamage = 0;
    }
}
