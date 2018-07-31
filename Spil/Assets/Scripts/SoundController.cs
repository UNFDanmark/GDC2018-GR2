using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    //lyd variabler
    public AudioClip walk;
    public AudioClip[] zombie;
    public AudioSource audioSource;//Vores audioSource
    


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
    public void zombiewalk() {
        int i = Random.Range(0, zombie.Length); // Random Generator
        audioSource.clip = zombie[i]; //Sæt lydklipppet i audioSource til den randomvalgte værdi
        if (!audioSource.isPlaying) //Tjekker om lyden allerede afspilles 
        {
            audioSource.Play(); //Afspiller lyden
        }

    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
