using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed_player = 10f;
    public float rotationSpeed_player = 10f;
    public float vomitMeter = 100f;
    public int health_player = 100;
    public int exp_player = 0;
    public int lvl_player = 1;
    public Rigidbody player;
    public GameObject Vomit;
    public Text vomitText;


    public float health_regen_sek_player = 1;
    public int vomit_player_regen_sek = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, rotationSpeed_player * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.Space) && vomitMeter > 0)
        {
            Shoot();
        }


    }

    private void FixedUpdate()
    {
        Move(speed_player * Input.GetAxis("Vertical"));
    }

    public void Move(float speed)
    {
        player.velocity = (Vector3.up * player.velocity.y) + (transform.forward * speed);
      
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(Vomit);
        newBullet.transform.position = transform.position + new Vector3(0, 0.75f, 0);
        newBullet.transform.rotation = transform.rotation;
        vomitMeter = vomitMeter - 0.1f;
        vomitText.text = "Vomit " + vomitMeter;


    }
}
