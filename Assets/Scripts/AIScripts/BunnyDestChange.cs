using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyDestChange : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            xPos = Random.Range(239, 283);
            zPos = Random.Range(221, 248);
            this.gameObject.transform.position = new Vector3(xPos, 2.77f, zPos);
        }
    }
}
