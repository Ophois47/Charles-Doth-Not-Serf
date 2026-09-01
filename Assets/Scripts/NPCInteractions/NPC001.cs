using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC001 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject NPCName;
    public GameObject NPCText;
    public GameObject NPCFace;
    public GameObject GateOpen;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            AttackBlocker.BlockSword = 1;
            ActionText.GetComponent<Text>().text = "Talk";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                AttackBlocker.BlockSword = 2;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //ThePlayer.SetActive(false);
                StartCoroutine(NPC001Active());
            }
        }
    }

    void OnMouseExit()
    {
        AttackBlocker.BlockSword = 0;
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator NPC001Active()
    {
        if (QuestManager.ActiveQuestNumber == 2)
        {
            NPCFace.SetActive(true);
            TextBox.SetActive(true);
            NPCName.GetComponent<Text>().text = "Devilish Imp";
            NPCName.SetActive(true);
            NPCText.GetComponent<Text>().text = "Hello again Flesh Sac! I can get you into the castle...But you must promise me you will take care of a particular unwelcome...pest, near my home. Head South, through the castle, and keep going until you find a well...";
            GateOpen.SetActive(true);
            NPCText.SetActive(true);
            yield return new WaitForSeconds(5.5f);
            NPCName.SetActive(false);
            NPCText.SetActive(false);
            NPCFace.SetActive(false);
            TextBox.SetActive(false);
            MasterQuest.mainQuestName = "The Devil's Homestead";
            MasterQuest.mainQuestInfo = "This pleasant Imp if the underworld has asked that I remove a rather large creature from the area of his dwelling. I am to travel through the castle, and follow the road south until I hit a small house near a well. Apparently the beast is something I can't miss...";
        }
        else
        {
            NPCFace.SetActive(true);
            TextBox.SetActive(true);
            NPCName.GetComponent<Text>().text = "Devilish Imp";
            NPCName.SetActive(true);
            NPCText.GetComponent<Text>().text = "Hello there mortal! I may have a task for you should you bear the courage to accept it. Come back after you have completed the job on the board!";
            NPCText.SetActive(true);
            yield return new WaitForSeconds(5.5f);
            NPCName.SetActive(false);
            NPCText.SetActive(false);
            NPCFace.SetActive(false);
            TextBox.SetActive(false);
        }
    }
}