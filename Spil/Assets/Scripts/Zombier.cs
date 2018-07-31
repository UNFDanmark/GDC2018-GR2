using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombier : MonoBehaviour
{

    public float speed_zombie = 0.5f;
    public Player player;
    public Vector3 direction_zombie;
    public Rigidbody zombiebody;
    public int zombieHealth = 10;
    public ZombieSpawn zombieSpawn;
    public float timeOfLastDestroy;
    public int skade = 5;
    public int slaghastighed = 2;
    public float lastHit;
    public NavMeshAgent myAgent;
    public GameObject kureret;
    public float spawnetTid;



    // Use this for initialization
    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();

    }

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        zombieSpawn = GameObject.FindObjectOfType<ZombieSpawn>();
        speed_zombie = Random.Range(2, 3);
        

    }

    // Update is called once per frame
    void Update()
    {
        //direction_zombie = player.transform.position - transform.position;
        //direction_zombie.Normalize();
        //Move_Z(direction_zombie);
        myAgent.SetDestination(player.transform.position);
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
            


            if (Time.time - timeOfLastDestroy >= 1)
            {
                Hidkalde();
                Destroy(gameObject);
                zombieSpawn.DestroyZombie();
                timeOfLastDestroy = Time.time;

            }


        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time - lastHit >= slaghastighed)
        {

            player.PlayerDamage(skade);
            lastHit = Time.time;
        }


    }

    public void Hidkalde()
    {
        Instantiate(kureret, transform.position, transform.rotation);
        

    }



}