using UnityEngine;
using System.Collections;

public class GhostTriggerApplication : MonoBehaviour {

	public GhostTriggerController controller;
	public GhostTriggerModel model;
	public GhostTriggerView view;
}

public class GhostTriggerElement : MonoBehaviour{
	public GhostTriggerApplication app{
		get{
			return GameObject.FindObjectOfType<GhostTriggerApplication> ();
		}
	}
}
