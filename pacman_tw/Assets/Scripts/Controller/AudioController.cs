﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {

	public GameObject button;
	public void Mute() {
		if (!AudioListener.pause) {
			AudioListener.pause = true;
			button.GetComponentInChildren<Text> ().text = "UnMute";
		} else {
			AudioListener.pause = false;
			button.GetComponentInChildren<Text> ().text = "Mute";
		}
	} 
}
