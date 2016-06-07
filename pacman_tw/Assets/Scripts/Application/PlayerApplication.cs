using UnityEngine;
using System.Collections;

public class PlayerApplication : MonoBehaviour {
	public PlayerModel model;
	public PlayerController controller;
	public PlayerView view;

}


public class PlayerElement : MonoBehaviour{
	public PlayerApplication app{
		get{
			return GameObject.FindObjectOfType<PlayerApplication> ();
		}
	}
}
