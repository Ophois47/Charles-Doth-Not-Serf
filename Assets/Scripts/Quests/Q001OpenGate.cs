using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q001OpenGate : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TheGate;
    public GameObject BossSpider;
    public AudioSource GateOpen;
    public GameObject RGate;
    public GameObject LGate;
    public GameObject Gate2;


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            AttackBlocker.BlockSword = 1;
            ActionText.GetComponent<Text>().text = "Open Gate";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                GetComponent<BoxCollider>().enabled = false;
                AttackBlocker.BlockSword = 2;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ActionText.GetComponent<Text>().text = "";
                GateOpen.Play();
                TheGate.GetComponent<Animation>().Play("GateMove");
                LGate.GetComponent<Animation>().Play("LGateOpen");
                RGate.GetComponent<Animation>().Play("RGateOpen");
                Gate2.GetComponent<Animation>().Play("Gate2Open");
                StartCoroutine(BossSpiderTrigger());
            }
        }
    }

    void OnMouseExit()
    {
        AttackBlocker.BlockSword = 0;
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator BossSpiderTrigger()
    {
        yield return new WaitForSeconds(80);
        BossSpider.SetActive(true);
    }
}
