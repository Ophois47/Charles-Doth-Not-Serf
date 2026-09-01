using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest002Start : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public AudioSource GateOpen;

    void Start()
    {
        
    }

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionText.GetComponent<Text>().text = "Open Gate";
            AttackBlocker.BlockSword = 1;
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                AttackBlocker.BlockSword = 2;
                GateOpen.Play();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
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
