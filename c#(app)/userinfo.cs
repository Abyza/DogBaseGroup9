
using UnityEngine;

public class userinfo : MonoBehaviour
{
    string userID;
    string userName;
    string userPassword;

    public void SetInfo(string username, string userpassword)
    {
        userName = username;
        userPassword = userpassword;
    }

}
