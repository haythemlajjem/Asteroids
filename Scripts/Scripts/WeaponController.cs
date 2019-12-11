// script de controle des coups des ennemies (durée entre les coups automatiques, le son des coups)

using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource r;

    void Start()
    {
        r = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        r.Play();
    }
}
