using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public TMP_InputField name_field;
    public TMP_InputField pass_field;
    public Button loginButton;

    private void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
            StartCoroutine(main.Instance.web.Login(name_field.text, pass_field.text));
        });
    }

}
