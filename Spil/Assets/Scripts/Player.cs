using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed_player = 10f;
    public float rotationSpeed_player = 10f;
    public float vomitMeter = 100f;
    public int health_player = 100;
    public int exp_player = 0;
    public int lvl_player = 1;
    public Rigidbody player;
    public Text VomitRange;
    public float PowerUp_activate;
    public float PowerUp_tid = 5;

    public GameObject  Vomit;
    public Vomit Vmit;
    public Text vomitText;
    public float timeOfLastRegen;
    public Text healthText;
    public float skifteTid = 0.2f;
    public float sidstSkiftet;
    public float range;
    public float timeOfLastRegenHealth;
    public GameObject Level_n;
    public GameObject regnbue;



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

            gameObject.GetComponentInChildren<ParticleSystem>().Play();  
            gameObject.GetComponent<SoundVomit>().vomitMethod();
        } else if(Time.time - timeOfLastRegen >= vomit_player_regen_sek && vomitMeter <= 99)
        {
            vomitMeter++;
            timeOfLastRegen = Time.time;
            vomitText.text = "Vomit: " + Mathf.Round(vomitMeter);
            gameObject.GetComponent<SoundVomit>().stopVomit();
         

        } else {
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        }
        if (health_player <= 99 && health_regen_sek_player <= Time.time - timeOfLastRegenHealth)
        {
            health_player++;
            timeOfLastRegenHealth = Time.time;
            healthText.text = "Health: " + health_player;
                }
        if (Time.time - PowerUp_activate >= PowerUp_tid)
        {
            rotationSpeed_player = 200;

        }

        

      /*  if (Input.GetKeyDown(KeyCode.E) )
        {
           range = Vmit.UpdateRange();
           VomitRange.text = "Range: \n" + range *2 ;
        } */
    }

    private void FixedUpdate()
    {
     
        Move(speed_player * Input.GetAxis("Vertical"));
    }

    public void Move(float speed)
    {
        if (speed < 0)
        {
            player.velocity = (Vector3.up * player.velocity.y) + (transform.forward * (speed/2));
            gameObject.GetComponent<SoundController>().walkMethod();
        } else
        {
            player.velocity = (Vector3.up * player.velocity.y) + (transform.forward * speed);
            if (speed > 0)
            {
                gameObject.GetComponent<SoundController>().walkMethod();
            }
            else {
                gameObject.GetComponent<SoundController>().stopWalk();
            }
        }
        
      
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(Vomit);
        newBullet.transform.position = transform.position + new Vector3(0, -0.75f, 0.25f);
        newBullet.transform.rotation = transform.rotation;
        vomitMeter = vomitMeter - 0.1f;
        vomitText.text = "Vomit: " + Mathf.Round(vomitMeter);
    }
    
        
    public void PlayerDamage(int skade)
    {
        if (health_player > 0)
        {
            health_player = health_player - skade;
            healthText.text = "Health: " + health_player;
        } else {
          
            DontDestroyOnLoad(Level_n);
            SceneManager.LoadScene("DeathScene");
        }

    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("FuldVomit") )
        {
            vomitMeter = 100;
            vomitText.text = "Vomit: " + Mathf.Round(vomitMeter);
        }
        if (trigger.CompareTag("FuldHealth"))
        {
            health_player = 100;
            healthText.text = "Health: " + health_player;
        }
        if (trigger.CompareTag("ExtremeRotation"))
        {
            rotationSpeed_player = 1000;
            PowerUp_activate = Time.time;

        }
        trigger.GetComponentInParent<PowerUpScript>().Puff();



        }
    }

