﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombier : MonoBehaviour
{

    public float speed_zombie = 0.5f;
    public Player player;
    public Vector3 direction_zombie;
    public Rigidbody zombiebody;
    public int zombieHealth = 10;
    public ZombieSpawn zombieSpawn;

 
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        zombieSpawn = GameObject.FindObjectOfType<ZombieSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        direction_zombie = player.transform.position - transform.position;
        direction_zombie.Normalize();
        Move_Z(direction_zombie);
    }

    public void Move_Z(Vector3 a) {
        
        //zombiebody.velocity = a + (enhed_vector * speed_zombie);
        //Mulighed for at gøre farten uafhængig af afstanden til player.
        zombiebody.velocity = a * speed_zombie;


    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Vomit") && zombieHealth > 0)
        {
            zombieHealth--;
        } else
        {
            Destroy(gameObject);
            zombieSpawn.DestroyZombie();
            
        }
    }


}