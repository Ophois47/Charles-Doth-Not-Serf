using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalExp : MonoBehaviour
{
    public static int CurrentExp;
    public int InternalExp = 0;
    public GameObject XPDisplay;



    void Update()
    {
        InternalExp = CurrentExp;
        XPDisplay.GetComponent<Text>().text = " XP: " + InternalExp;
    }
}
