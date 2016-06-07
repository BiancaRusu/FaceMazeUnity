using UnityEngine;
using System.Collections;

public class LevelManagementApplication : MonoBehaviour {

	public LevelManagementController controller;
	public LevelManagementModel model;
	public LevelManagementView view;
}

public class LevelManagementElement : MonoBehaviour{
	public LevelManagementApplication app{
		get{
			return GameObject.FindObjectOfType<LevelManagementApplication> ();
		}
	}
}
