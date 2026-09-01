using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtflyDestChange1 : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            xPos = Random.Range(159, 186);
            zPos = Random.Range(156, 228);
            this.gameObject.transform.position = new Vector3(xPos, 5.4f, zPos);
        }
    }
}
