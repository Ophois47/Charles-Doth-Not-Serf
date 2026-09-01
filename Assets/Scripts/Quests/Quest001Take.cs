using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest001Take : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject UIQuest;
    public GameObject ThePlayer;
    public GameObject NoticeCam;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            AttackBlocker.BlockSword = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<Text>().text = "Read Note";
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                AttackBlocker.BlockSword = 2;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                UIQuest.SetActive(true);
                NoticeCam.SetActive(true);
                ThePlayer.SetActive(false);
                MasterQuest.mainQuestName = "First Blade";
                MasterQuest.mainQuestInfo = "I'm to find the Dragonblade? I must be retrieved from the forest. 100 Gold pieces are being offered for this and I may get to keep the blade.";
            }
        }
    }

    void OnMouseExit()
    {
        AttackBlocker.BlockSword = 0;
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
