using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadescript : MonoBehaviour
{

    public CanvasGroup loginCanvas;
    public CanvasGroup mainCanvas;

    public bool fadeOut;

    public bool fadeInMainCanvas;


    private void Start()
    {
        loginCanvas.alpha = 1;
        mainCanvas.alpha = 0;
        mainCanvas.interactable = false;
    }

    public void enterMain()
    {
        fadeOut = true;

    }

    public void fadeInMain()
    {
        fadeInMainCanvas = true;
    }

    private void Update()
    {
        if(fadeOut)
        {
            Debug.Log("fading out");
            if(loginCanvas.alpha>=0)
            {
                loginCanvas.alpha -= Time.deltaTime;
                if(loginCanvas.alpha ==0)
                {
                    fadeOut = false;
                    loginCanvas.interactable = false;
                    fadeInMain();
                }

            }

        }

        if (fadeInMainCanvas)
        {
            Debug.Log("fading out");
            if (mainCanvas.alpha < 1)
            {
                mainCanvas.alpha += Time.deltaTime;
                if (mainCanvas.alpha >= 1)
                {
                    mainCanvas.interactable = true;
                    mainCanvas.blocksRaycasts = true;
                    fadeInMainCanvas = false;
                  
                  
                }

            }

        }
    }



}
