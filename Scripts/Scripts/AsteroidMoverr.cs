﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMoverr : MonoBehaviour {

    public Rigidbody rb;
    public float speed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    //mouvement aléatoire de l'astéroide 1 
    void Update()
    {
        Vector3 Movement = new Vector3(Random.Range(-1, 1), 0.0f, Random.Range(0, 2));
        rb.AddForce(Movement);
    }
}
