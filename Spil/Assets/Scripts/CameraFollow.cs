using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public bool GameActive = false;
    //public static Vector3 Lerp;
    //public float t = 4;
    //public bool transitionActive = false;
    //public float transitionStart;
    //public float floatSpeed = 10f;
    //public float journeyLength;
    // Use this for initialization
    void Start() {
        offset = new Vector3(0f, 9.12f, -10.27f) - player.position;

        //journeyLength = Vector3.Distance(new Vector3(0f, 47.4f, -56.6f), new Vector3(0f, 9.12f, -10.27f));
    }

    // Update is called once per frame
    void Update() {
        if (GameActive)
        {
        transform.position = player.position + offset;

        }
        //if (transitionactive)
        //{
        //    transitionstart = time.time;
        //    // distance moved = time * speed.
        //    float distcovered = (time.time - transitionstart) * floatspeed;
        //    // fraction of journey completed = current distance divided by total distance.
        //    float fracjourney = distcovered / journeylength;
        //    // set our position as a fraction of the distance between the markers.
        //    transform.position = vector3.lerp(new vector3(0f, 47.4f, -56.6f), new vector3(0f, 9.12f, -10.27f), fracjourney);


        //    if (time.time - transitionstart > t)
        //    {
        //        // gameactive = true;
        //    }
        //}

    }

    public void KameraMenu()
    {
        transform.position = new Vector3(0f, 32.96f, -39.11f);
        
    }
    public void KameraStart()
    {
        //transitionActive = true;
        GameActive = true;
        
        
    }

}
