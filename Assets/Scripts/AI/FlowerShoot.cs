using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerShoot : MonoBehaviour
{
    public Rigidbody Bullet;
    public float Velocity;
    private Transform target;

    void Start()
    {
        Velocity = 1000;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Physics.Linecast(transform.position, target.position))
        {
            Bullet.AddForce(transform.forward * Velocity * Time.deltaTime, ForceMode.Impulse);
            Debug.Log("blocked");
        }
    }

}