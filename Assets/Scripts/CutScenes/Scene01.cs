using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01 : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject FadeOut;
    public GameObject FadeIn;
    public GameObject ThePlayer;
    public GameObject AuthorText;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject SignCollider;
    public GameObject Reticle;
    public GameObject MiniMap;
    public GameObject MiniMapCam;
    public GameObject GlobalMults;
    public GameObject StatusBar;

    void Start()
    {
        StartCoroutine(CutSceneStart());
    }

    IEnumerator CutSceneStart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MiniMap.SetActive(false);
        MiniMapCam.SetActive(false);
        Reticle.SetActive(false);
        StatusBar.SetActive(false);
        //Heart1.SetActive(false);
        //Heart2.SetActive(false);
        //Heart3.SetActive(false);
        //Heart4.SetActive(false);
        GlobalMults.SetActive(false);
        Text1.SetActive(true);
        Text2.SetActive(true);
        yield return new WaitForSeconds(9);
        Camera2.SetActive(true);
        Camera1.SetActive(false);
        FadeIn.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        AuthorText.SetActive(true);
        yield return new WaitForSeconds(8);
        SignCollider.SetActive(false);
        AuthorText.SetActive(false);
        Camera3.SetActive(true);
        Camera2.SetActive(false);
        yield return new WaitForSeconds(12);
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        ThePlayer.SetActive(true);
        FadeIn.SetActive(true);
        FadeOut.SetActive(false);
        Camera3.SetActive(false);
        FadeOut.SetActive(false);
        //Heart1.SetActive(true);
        //Heart2.SetActive(true);
        //Heart3.SetActive(true);
        //Heart4.SetActive(true);
        StatusBar.SetActive(true);
        GlobalMults.SetActive(true);
        Reticle.SetActive(true);
        MiniMap.SetActive(true);
        MiniMapCam.SetActive(true);
        yield return new WaitForSeconds(5);
        SignCollider.SetActive(true);
        FadeIn.SetActive(false);
    }
}
