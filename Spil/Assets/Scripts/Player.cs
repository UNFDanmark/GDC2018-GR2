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
    public Text VomitRange;

    public GameObject  Vomit;
    public Vomit Vmit;
    public Text vomitText;
    public float timeOfLastRegen;
    public Text healthText;
    public float skifteTid = 0.2f;
    public float sidstSkiftet;
    public float range;


    public float health_regen_sek_player = 1;
    public float vomit_player_regen_sek = 1f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, rotationSpeed_player * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.Space) && vomitMeter > 0)
        {
            Shoot();
        } else if(Time.time - timeOfLastRegen >= vomit_player_regen_sek && vomitMeter <= 99)
        {
            vomitMeter++;
            timeOfLastRegen = Time.time;
            vomitText.text = "Vomit: " + Mathf.Round(vomitMeter);
        }
        if (Input.GetKeyDown(KeyCode.E) )
        {
           range = Vmit.UpdateRange();
           VomitRange.text = "Range: \n" + range *2 ;
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
        vomitText.text = "Vomit: " + Mathf.Round(vomitMeter);


    }
    
        
    public void PlayerDamage(int skade)
    {
        health_player = health_player - skade;
        healthText.text = "Health: " + health_player;
    }
}
