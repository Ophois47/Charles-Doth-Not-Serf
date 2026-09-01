using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLevel : MonoBehaviour
{
    public static int CurrentLevel = 1;
    public int InternalLevel;

    void Update()
    {
        InternalLevel = CurrentLevel;
    }
}
