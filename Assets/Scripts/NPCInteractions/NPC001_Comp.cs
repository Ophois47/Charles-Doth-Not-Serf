using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC001_Comp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject NPCName;
    public GameObject NPCText;
    public GameObject NPCFace;
    public GameObject TheCave;

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
        if (QuestManager.ActiveQuestNumber == 2 && QuestManager.SubQuestNumber == 4)
        {
            NPCFace.SetActive(true);
            TextBox.SetActive(true);
            NPCName.GetComponent<Text>().text = "Devilish Imp";
            NPCName.SetActive(true);
            NPCText.GetComponent<Text>().text = "You have done what I physcally could not within this realm and for that I thank you. Keep the sword. There is also a cave behind the castle that you may find of interest...";
            //CaveObject set here
            QuestManager.ActiveQuestNumber = 5;
            QuestManager.SubQuestNumber = 5;
            NPCText.SetActive(true);
            yield return new WaitForSeconds(5.5f);
            NPCName.SetActive(false);
            NPCText.SetActive(false);
            NPCFace.SetActive(false);
            TextBox.SetActive(false);
            MasterQuest.mainQuestName = "Deep and Dark";
            MasterQuest.mainQuestInfo = "The unsuspicious spawn of Satan has turned me on to a dangerous cave in the mountains, I believe it would be best to investigate!";
        }
        else
        {
            NPCFace.SetActive(true);
            TextBox.SetActive(true);
            NPCName.GetComponent<Text>().text = "Devilish Imp";
            NPCName.SetActive(true);
            NPCText.GetComponent<Text>().text = "See me again after you have explored the cave...";
            NPCText.SetActive(true);
            yield return new WaitForSeconds(5.5f);
            NPCName.SetActive(false);
            NPCText.SetActive(false);
            NPCFace.SetActive(false);
            TextBox.SetActive(false);
        }
    }
}