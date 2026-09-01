using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{

    public GameObject player;

    bool m_IsPlayerAtExit;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }


    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            Application.Quit();
        }
    }
}
