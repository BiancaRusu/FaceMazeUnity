using UnityEngine;
using System.Collections;

public class ShareToSocialMedia : MonoBehaviour {

    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";

    public void  ShareToTwitter()
    {
        Application.OpenURL(TWITTER_ADDRESS +
                    "?text=" + "Jucand FaceMaze" +
                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }
}
