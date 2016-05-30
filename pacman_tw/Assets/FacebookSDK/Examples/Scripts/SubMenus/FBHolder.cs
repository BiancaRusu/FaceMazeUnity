using UnityEngine;
using System.Collections;
using Facebook.Unity;


public class FBHolder : MonoBehaviour
{

    void Awake()
    {
        FB.Init(SetInit, OnHideUnity);
    }

    private void SetInit()
    {
        Debug.Log("Facebook init done.");
        if (FB.IsLoggedIn)
        {
            Debug.Log("Facebook logged in.");
        }
        else
        {
            FBlogin();
        }
    }

    private void OnHideUnity(bool IsGameShown)
    {
        if (!IsGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void FBlogin()
    {
        FB.Login("user_email,user_friends_avatar,user_avatar", AuthCallBack);
    }

    void AuthCallBack(FBResult result)
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Facebook login worked.");
        }
        else
        {
            Debug.Log("Facebook login fail.");
        }
    }
}


