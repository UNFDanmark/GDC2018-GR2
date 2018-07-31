using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZombie : MonoBehaviour {
    public AudioClip[] zombie;
    private GameObject soundObject;//Vores audioSource
    private AudioSource audiosource;
    public float interval = 3f;
    private float lastPlayedAt = 0;


    // Use this for initialization
    void Awake () {
        soundObject = GameObject.FindWithTag("Sound");
        audiosource = soundObject.GetComponent<SoundLvlUp>().zombiesource;
	}
    
    // Update is called once per frame
    void Update () {
        if (Time.time - lastPlayedAt > interval) {
            zombiewalk();
            lastPlayedAt = Time.time;
        }
	}
    public void zombiewalk()
    {
        int i = Random.Range(0, zombie.Length); // Random Generator
        audiosource.clip = zombie[i]; //Sæt lydklipppet i audioSource til den randomvalgte værdi
        if (!audiosource.isPlaying) //Tjekker om lyden allerede afspilles 
        {
            audiosource.Play(); //Afspiller lyden
        }

    }
}
