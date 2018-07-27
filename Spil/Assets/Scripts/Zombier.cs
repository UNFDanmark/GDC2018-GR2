using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombier : MonoBehaviour
{

    public float speed_zombie = 0.5f;
    public Transform player;
    public Vector3 direction_zombie;
    public Rigidbody zombiebody;
 
    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        direction_zombie = player.position - transform.position;
        Move_Z(direction_zombie);
    }

    public void Move_Z(Vector3 a) {

        //zombiebody.velocity = a + (enhed_vector * speed_zombie);
        //Mulighed for at gøre farten uafhængig af afstanden til player.
        zombiebody.velocity = a * speed_zombie;


    }


}