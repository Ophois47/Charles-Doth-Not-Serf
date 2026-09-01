using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToDungeon : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ThePlayer;

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
            ActionText.GetComponent<Text>().text = "Enter Dungeon";
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                SceneManager.LoadScene(3);
                ThePlayer.SetActive(true);
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
