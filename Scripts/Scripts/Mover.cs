//script de mouvement du coup de joueur et des ennemies 

using UnityEngine;
using System.Collections;
[System.Serializable]

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>() ;
        rb.velocity = transform.forward * speed;
    }
}