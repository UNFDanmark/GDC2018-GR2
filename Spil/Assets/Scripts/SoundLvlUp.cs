using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLvlUp : MonoBehaviour {
    public AudioSource audiosource;
    public AudioClip lvlUp;
    public AudioSource zombiesource;

    public void LevelUp() {
        audiosource.clip = lvlUp; //sætter lyden i audioSource
        audiosource.Play();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
