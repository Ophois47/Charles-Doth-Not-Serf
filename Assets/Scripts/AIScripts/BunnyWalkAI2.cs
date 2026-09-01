using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyWalkAI2 : MonoBehaviour
{
    public int XPos;
    public int ZPos;
    public GameObject BunnyNPCDest;

    void Start()
    {
        XPos = Random.Range(239, 283);
        ZPos = Random.Range(221, 248);
        BunnyNPCDest.transform.position = new Vector3(XPos, 2.77f, ZPos);
        StartCoroutine(RunRandomWalk());
    }

    void Update()
    {
        transform.LookAt(BunnyNPCDest.transform);
        transform.position = Vector3.MoveTowards(transform.position, BunnyNPCDest.transform.position, 0.01f * Time.timeScale);
    }

    IEnumerator RunRandomWalk()
    {
        yield return new WaitForSeconds(8);
        XPos = Random.Range(239, 283);
        ZPos = Random.Range(221, 248);
        BunnyNPCDest.transform.position = new Vector3(XPos, 2.77f, ZPos);
        StartCoroutine(RunRandomWalk());
    }
}
