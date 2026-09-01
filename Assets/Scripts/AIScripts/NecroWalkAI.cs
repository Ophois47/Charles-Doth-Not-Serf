using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroWalkAI : MonoBehaviour
{
    public int XPos;
    public int ZPos;
    public GameObject NPCDest;

    void Start()
    {
        XPos = Random.Range(175, 189);
        ZPos = Random.Range(155, 210);
        NPCDest.transform.position = new Vector3(XPos, 2.102f, ZPos);
        StartCoroutine(RunRandomWalk());
    }

    void Update()
    {
        transform.LookAt(NPCDest.transform);
        transform.position = Vector3.MoveTowards(transform.position, NPCDest.transform.position, 0.04f * Time.timeScale);
    }

    IEnumerator RunRandomWalk()
    {
        yield return new WaitForSeconds(5);
        XPos = Random.Range(175, 189);
        ZPos = Random.Range(155, 210);
        NPCDest.transform.position = new Vector3(XPos, 2.102f, ZPos);
        StartCoroutine(RunRandomWalk());
    }
}
