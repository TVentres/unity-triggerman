using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeBetweenWaves=7.0f;
    public float timer=0.0f;
    public bool canSpawn=false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        //Debug.Log(timer);
        if(timer >=timeBetweenWaves)
        {
            canSpawn=true;
        }
    }

    public void hasSpawned()
    {
        canSpawn=false;
        timer=0.0f;
    }
}

