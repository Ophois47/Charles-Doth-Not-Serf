using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q001Objective03 : MonoBehaviour
{

    public float TheDistance;
    public GameObject FakeSword;
    public GameObject RealSword;
    public GameObject ActionText;
    public GameObject ActionDisplay;
    public GameObject TheObjective;
    public int CloseObjective;
    public GameObject ChestBlock;
    public GameObject QuestComplete;
    public GameObject ExMark;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
        if (CloseObjective == 3)
        {
            TheObjective.SetActive(false);
            if (TheObjective.transform.localScale.y <= 0.0f)
            {
                CloseObjective = 0;
                TheObjective.SetActive(false);
            }
            else
            {
                TheObjective.transform.localScale -= new Vector3(0.0f, 0.01f, 0.0f);
            }
        }

    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ActionText.GetComponent<Text>().text = "Take Your Blade!";
            ActionText.SetActive(true);
            ActionDisplay.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                QuestManager.SubQuestNumber = 3;
                this.GetComponent<BoxCollider>().enabled = false;
                FakeSword.SetActive(false);
                RealSword.SetActive(true);
                ChestBlock.SetActive(true);
                CloseObjective = 3;
                ActionText.SetActive(false);
                ActionDisplay.SetActive(false);
                ExMark.SetActive(true);
                QuestComplete.SetActive(true);
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
