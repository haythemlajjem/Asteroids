// script de controle du joueur 
using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private Rigidbody rb;
    private AudioSource r;
    public Boundary boundary;
    private float nextFire;

    //le code qui permet au joueur de tirer les ennemies et les astéroides 
    void Update()
    {
        
        if (Input.GetKeyDown("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            r = GetComponent<AudioSource>();
            r.Play();
        }
    }

    //controle de mouvement du joueur 
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime/10);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        rb = GetComponent<Rigidbody>();

        //limite de déplacement du joueur
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

    }
}