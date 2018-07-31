using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVomit : MonoBehaviour {
    public AudioClip vomit_start;
    public AudioClip vomit;
    public AudioSource audioSource;//Vores audioSource


    public void vomitMethod()
    {
        audioSource.clip = vomit;
        if (!audioSource.isPlaying) //tjekker om lyden allerede afspilles
        {
            audioSource.Play(); //afspiller lyden
        }
    }
    public void stopVomit() {
        audioSource.Stop();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
