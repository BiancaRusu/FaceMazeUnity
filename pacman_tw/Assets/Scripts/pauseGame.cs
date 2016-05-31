using UnityEngine;
using System.Collections;

public class pauseGame : MonoBehaviour
{

    public bool paused;
    public AudioSource[] audioSourcesToIgnore;
    // Use this for initialization
    void Start()
    {
        foreach (AudioSource snd in audioSourcesToIgnore)
        {
            snd.ignoreListenerPause = true;
        }
    }

    public void Pause()
    {
        paused = !paused;


        if (paused)
        {
            Time.timeScale = 0.0f;
            AudioListener.pause = true;
            
        }
        else
        {
            Time.timeScale = 1.0f;
            AudioListener.pause = false;
            
        }
    }
}
