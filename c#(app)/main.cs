using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public static main Instance;

    public web web;
    public userinfo userinfo;

    public GameObject loginWindow;
    public GameObject mainWindow;
    public fadescript fade;

    private void Start()
    {
        //loginWindow.SetActive(true);
       // mainWindow.SetActive(false);
        Instance = this;
        web = GetComponent<web>();
        userinfo = GetComponent<userinfo>();
    }

    public void transitionToMain()
    {
        fade.enterMain();

    }
    public void quitDogBase()
    {
        Application.Quit();
    }

}
