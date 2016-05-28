using UnityEngine;
using System.Collections;
using Facebook.Unity;

public class FacebookLogin : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
        }
	
	}

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            FacebookLogin();
        }
        else
        {
            Debug.Log("Failed to initialized Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void FacebookLogin()
    {
        var permissions = new List<string>(){ "public_profile" ,"email","user_friends"};
        FB.LogInWithPublishPermissions(permissions, AuthCallback);
    }
	
	// Update is called once per frame

    private AuthCallback(ILoginResult result){
        if(FB.IsLoggedIn){

        }
    }

	void Update () {
	
	}
}
