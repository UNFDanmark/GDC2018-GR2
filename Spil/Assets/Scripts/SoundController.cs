using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    //lyd variabler
    public AudioClip walk;
    public AudioSource audioSource;//Vores audioSource
    public AudioSource zombiesource;


    public void walkMethod() //metode
    {
        audioSource.clip = walk; //sætter lyden i audioSource
        if (!audioSource.isPlaying) //tjekker om lyden allerede afspilles
        {
            audioSource.Play(); //afspiller lyden
        }
    }
    public void stopWalk() {
        audioSource.Stop();
    }
    
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
