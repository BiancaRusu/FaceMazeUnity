using UnityEngine;
using System.Collections;

public class ShareOnTwitterController : MonoBehaviour {

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en"; 

	public void Share ()
	{	
		string url = TWITTER_ADDRESS + "?text=" + WWW.EscapeURL ("Jucand #FaceMaze am fost mancat de " + globalVariables.theGhostThatAteMe) + "&amp;lang=" + WWW.EscapeURL (TWEET_LANGUAGE);
		Application.OpenURL (url);



	}
}
