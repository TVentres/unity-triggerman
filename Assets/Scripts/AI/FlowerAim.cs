using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAim : MonoBehaviour
{
    private Transform target;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3( target.position.x, this.transform.position.y, target.position.z ) ;
        this.transform.LookAt(playerPosition);
    }
}
