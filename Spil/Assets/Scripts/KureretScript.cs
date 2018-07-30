using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KureretScript : MonoBehaviour {
    public float spawnetTid;
    public float livsTid;


	// Use this for initialization
	void Start () {
        spawnetTid = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - spawnetTid > livsTid)
        {
            Destroy(gameObject);
        }
	}
}
