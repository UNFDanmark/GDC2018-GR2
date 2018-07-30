using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawn : MonoBehaviour {

    public int antal_zombie = 0;
    public int intended_zombies = 5;
    public GameObject zombie;
    public Transform player;
    public float zombiedistance = 10;
    public int level_1 = 0;
    public int i;
    public Text levelText;
    public Text zombieText;
    public int mapSize = 38;
    public LevelInfoScript gitGutLevel;
    
    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (antal_zombie == 0)
        {
            level_1++;
            levelText.text = "Level: " + level_1;
            gitGutLevel.levelInfo = level_1;
            for (int i = 0; i < level_1 * 5;)
            {

                if (Spawn())
                {
                    i++;
                    zombieText.text = "Zombier: " + antal_zombie;
                }
            }
            }
        }

            public bool Spawn()
        {
            float x = Random.Range(-mapSize, mapSize);
            float z = Random.Range(-mapSize, mapSize);

            float x1 = player.position.x;
            float z1 = player.position.z;
            float regnestykke = Mathf.Sqrt(Mathf.Pow(x + x1, 2) + Mathf.Pow(z + z1, 2));

            if (regnestykke > zombiedistance)
            {

                Vector3 position = new Vector3(x, 1f, z);
                Instantiate(zombie, position, Quaternion.identity);
                antal_zombie++;
            return true;
            }
            
            else
        {
            return false;


        }
        
        
	}
            public void DestroyZombie()
                {
                    antal_zombie--;
                    zombieText.text = "Zombier: " + antal_zombie;
    }

    }

