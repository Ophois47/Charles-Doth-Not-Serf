using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest001Complete : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject UIQuest;
    public GameObject ThePlayer;
    public GameObject ExMark;
    public GameObject CompleteTrigger;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<Text>().text = "Complete Quest";
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                QuestManager.SubQuestNumber = 0;
                GlobalCash.GoldAmount += 100;
                PlayerPrefs.SetInt("GoldAmountSave", GlobalCash.GoldAmount);
                ExMark.SetActive(false);
                GlobalExp.CurrentExp += 100;
                PlayerPrefs.SetInt("ExpSave", GlobalExp.CurrentExp);
                QuestManager.ActiveQuestNumber = 2;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                CompleteTrigger.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
