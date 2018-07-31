using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneScript : MonoBehaviour {
    public Text Level1Info;
    
    
    public LevelInfoScript Levelnr;
	// Use this for initialization
	void Start () {
         
        Levelnr = GameObject.FindWithTag("LevelNummer").GetComponent<LevelInfoScript>();
        Level1Info.text = "Level: " + Levelnr.levelInfo;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("VoresScene");
        }
    }
}
