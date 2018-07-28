﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour {
    public float moveSpeed;
    public float moveUpSpeed;
    public float lifeTime = 5;
    public float explosionPower = 9001;
    public float explosionRadius = 5;
    public Rigidbody myRigidbody;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        myRigidbody.velocity = transform.forward * moveSpeed + transform.up * moveUpSpeed;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + myRigidbody.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        Explode();

        //hitRigidbody.AddExplosionForce(explosionPower, transform.position, explosionRadius, 0, ForceMode.Impulse);
    }

    public void Explode()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyCollider in nearbyColliders)
        {
            if (nearbyCollider.CompareTag("Cage"))
            {
                PushObject(nearbyCollider.gameObject);
            }
        }
        Destroy(gameObject);
    }

    public void PushObject(GameObject target)
    {
        Rigidbody hitRigidbody = target.GetComponent<Rigidbody>();
        Vector3 explosionDirection = hitRigidbody.transform.position - transform.position;
        explosionDirection.Normalize();
        hitRigidbody.AddForce(explosionDirection * explosionPower, ForceMode.Impulse);
    }
}
