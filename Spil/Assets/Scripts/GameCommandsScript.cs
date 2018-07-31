using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommandsScript : MonoBehaviour
{

    public GameObject SpilText;
    public CameraFollow Camera;
    public GameObject StartKnap;
    public AudioSource audiosource;
    public AudioClip start;
    public AudioClip lvlUp;
    
    
    private void Awake()
    {
        
        StartMenu();
    }

    // Use this for initialization
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void StartGame()
    {
        SpilText.SetActive(true);
        Time.timeScale = 1;
        Camera.KameraStart();
        StartKnap.SetActive(false);
        audiosource.clip = start;
        audiosource.Play();
        
    }

    public void StartMenu()
    {
        Time.timeScale = 0;
        SpilText.SetActive(false);
        Camera.KameraMenu();
        
    }
    public void LevelUp() {
        audiosource.clip = lvlUp; //sætter lyden i audioSource
        audiosource.Play();
    }
   
}

