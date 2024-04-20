using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPlanes = new Transform[4];

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Spawning();
        }
    }

    public void Spawning()
    {
        
        //select a random plane from the available planes in the array
        Transform plane = spawnPlanes[UnityEngine.Random.Range(0,spawnPlanes.Length)];
        // Spawn the object as a child of the plane.
        GameObject obj = Instantiate(enemy, Vector3.zero, Quaternion.identity, plane) as GameObject;

        //Place object in center of plain
        obj.transform.position = new Vector3(plane.position.x, 3, plane.position.z);

        // Now unassign the parent
        obj.transform.parent = null;
    }
}
