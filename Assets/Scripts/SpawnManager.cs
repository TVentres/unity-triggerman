using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MultiArrays : MonoBehaviour
{
    public WaveStruct[] numbers = new WaveStruct[2];
}

//Wave struct. Each wave has an array of objects that will be spawned in that wave.
[System.Serializable]
public struct WaveStruct
{
    //public GameObject[] enemyList = GameObject[1];
    public int[] moreNumbers;
}

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPlanes = new Transform[4];
    
    //keeps track of how many enamies will be in each wave. ie enemyCountPerWave[0] gives the number of enemies for wave 0
    public int[] enemyCountPerWave = { 1, 2, 3, 4 };
    public int currentWave=0;
    //public int[] numbers = { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 } };

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
