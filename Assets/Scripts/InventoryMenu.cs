using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class InventoryMenu : MonoBehaviour
{

    public bool invOpen = false;
    public GameObject invMenu;
    public GameObject thePlayer;
    public GameObject itemPanel;
    public GameObject questPanel;
    public GameObject statPanel;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (invOpen == false)
            {
                Time.timeScale = 0;
                invOpen = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                invMenu.SetActive(true);
                thePlayer.GetComponent<FirstPersonController>().enabled = false;
            }
            else
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = true;
                invMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                invOpen = false;
                Time.timeScale = 1;
            }
        }
    }

    public void ShowItem()
    {
        itemPanel.SetActive(true);
        questPanel.SetActive(false);
        statPanel.SetActive(false);
    }

    public void ShowQuest()
    {
        itemPanel.SetActive(false);
        questPanel.SetActive(true);
        statPanel.SetActive(false);
    }

    public void ShowStat()
    {
        itemPanel.SetActive(false);
        questPanel.SetActive(false);
        statPanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        StartCoroutine(MainMenu());
    }

    public void CloseMenu()
    {
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        invMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        invOpen = false;
        Time.timeScale = 1;
    }

    IEnumerator MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(0.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
