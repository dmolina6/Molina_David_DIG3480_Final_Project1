using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;
    public GameObject shot;
    public Transform shotspawn;
    public Transform shotspawn2;
    public Transform shotspawn3;
    public bool doubleshot;
    public bool tripleshot;
    public float fireRate;
    private float nextFire = 0.5F;    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        doubleshot = false;
        tripleshot = false;
    }

    private void Update()
    {
        int i;
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (doubleshot)
            {
                for (i=0; i < 10; i++)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotspawn2.position, shotspawn2.rotation);
                    Instantiate(shot, shotspawn3.position, shotspawn3.rotation);
                }
                doubleshot = false;
            }
            if (tripleshot)
            {
                for (i = 0; i < 10; i++)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotspawn.position, shotspawn.rotation);
                    Instantiate(shot, shotspawn2.position, shotspawn2.rotation);
                    Instantiate(shot, shotspawn3.position, shotspawn3.rotation);
                }
                tripleshot = false;                
            }
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Double"))
        {
            other.gameObject.SetActive(false);
            doubleshot = true;
        }
        if (other.gameObject.CompareTag("Triple"))
        {
            other.gameObject.SetActive(false);
            tripleshot = true;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }   
    }