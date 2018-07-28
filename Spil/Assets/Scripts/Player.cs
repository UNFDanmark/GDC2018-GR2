using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed_player = 10f;
    public float rotationSpeed_player = 10f;
    public int health_player = 100;
    public int exp_player = 0;
    public int lvl_player = 1;
    public Rigidbody player;


    public float health_regen_sek_player = 1;
    public int vomit_player_regen_sek = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, rotationSpeed_player * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        Move(speed_player * Input.GetAxis("Vertical"));
    }

    public void Move(float speed)
    {
        player.velocity = (Vector3.up * player.velocity.y) + (transform.forward * speed);
      
    }
    
}
