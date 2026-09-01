using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthMonitor : MonoBehaviour
{
    public static int HealthValue;
    public int InternalHealth;
    //public GameObject Heart1;
    //public GameObject Heart2;
    //public GameObject Heart3;
    //public GameObject Heart4;
    public GameObject HealthBar;


    void Start()
    {
        HealthValue = 240;
    }

    void Update()
    {
        InternalHealth = HealthValue;

        if (HealthValue <= 0)
        {
            StartCoroutine(GameOver());
        }

        HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(HealthValue, 110);

        //Hearts System
        //if(HealthValue == 1)
        //{
        //    Heart1.SetActive(true);
        //    Heart2.SetActive(false);
        //}
        //if (HealthValue == 2)
        //{
        //    Heart2.SetActive(true);
        //    Heart3.SetActive(false);
        //}
        //if (HealthValue == 3)
        //{
        //    Heart3.SetActive(true);
        //    Heart4.SetActive(false);
        //}
        //if (HealthValue == 4)
        //{
        //    Heart4.SetActive(true);
        //}
    }

    IEnumerator GameOver()
    {
        SceneManager.LoadScene(2);
        yield return new WaitForSeconds(3);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
