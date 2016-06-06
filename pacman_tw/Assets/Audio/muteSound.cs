using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class muteSound : MonoBehaviour {
	
	public GameObject button;
	public bool paused;
	void Start () {
	}

	public void Mute() {
			if (button.GetComponentInChildren<Text> ().text == "Mute") {
				AudioListener.pause = true;
			} else {
				AudioListener.pause = false;
			}
			paused = !paused;
			button.GetComponentInChildren<Text> ().text = paused == true ? "Mute" : "Unmute";
		}
}
