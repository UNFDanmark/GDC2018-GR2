using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawn : MonoBehaviour {

    public int antal_zombie = 0;
    public GameObject zombie;
    public GameObject zombieFast;
    public Transform player;
    public float zombiedistance = 20;
    public int level_1 = 0;
    public int i;
    public Text levelText;
    public Text zombieText;
    public int mapSize = 38;
    public LevelInfoScript gitGutLevel;
    public float tidVed0Z;
    public float pausetid = 0;
    public bool spawnstuf = true;
    public GameObject FullHealth;
    public GameObject FullVomit;
    public GameObject ExtremeRotatation;
    public Vector3 FullH = new Vector3(13, 4, 0);
    public Vector3 FullV = new Vector3(-13, 4, 0);


    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        if (antal_zombie == 0)
        {
            if (spawnstuf)
            {
                tidVed0Z = Time.time;
                spawnstuf = false;
                Instantiate(FullHealth, new Vector3(13, 0.5f, 0), Quaternion.identity);
                Instantiate(FullVomit, new Vector3(-13, 0.5f, 0), Quaternion.identity);
                
            }

            if (Time.time - tidVed0Z > pausetid)
            {
                level_1++;

                gameObject.GetComponent<SoundLvlUp>().LevelUp();


                levelText.text = "Level: " + level_1;
                gitGutLevel.levelInfo = level_1;
                LevelSpawn();
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
    public bool SpawnFast()
    {
        float x = Random.Range(-mapSize, mapSize);
        float z = Random.Range(-mapSize, mapSize);

        float x1 = player.position.x;
        float z1 = player.position.z;
        float regnestykke = Mathf.Sqrt(Mathf.Pow(x + x1, 2) + Mathf.Pow(z + z1, 2));

        if (regnestykke > zombiedistance)
        {

            Vector3 position = new Vector3(x, 1f, z);
            Instantiate(zombieFast, position, Quaternion.identity);
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


    public void LevelSpawn()
    {
        //gameObject.GetComponent<SoundLvlUp>().LevelUp();

     

        for (int i = 0; i < level_1 * 5;)
        {

            if (Spawn())
            {
                i++;
                zombieText.text = "Zombier: " + antal_zombie;
            }
        }
        for (int i = 0; i < level_1 * 2;)
        {

            if (SpawnFast())
            {
                i++;
                zombieText.text = "Zombier: " + antal_zombie;
            }
        }
        SpawnRot();
        spawnstuf = true;
    }

    public void SpawnRot(){
        float x = Random.Range(-mapSize, mapSize);
        float z = Random.Range(-mapSize, mapSize);

        

            Vector3 position = new Vector3(x, 0.5f, z);
            Instantiate(ExtremeRotatation, position, Quaternion.identity);
            
        
    }
    }

