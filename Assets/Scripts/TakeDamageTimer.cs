using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageTimer : MonoBehaviour
{
    public float timeBetweenHits=3.0f;
    public float timer=0.0f;
    public bool canHit=true;
    // Start is called before the first frame update

    // Update is called once per frame
    //GameObject.Find("objectWithTimerScript").GetComponent<Timer>().hasSpawned();
    void Update()
    {
        timer+=Time.deltaTime;
        //Debug.Log(timer);
        if(timer >=timeBetweenHits)
        {
            canHit=true;
        }
    }

    public void gotHit()
    {
        canHit=false;
        timer=0.0f;
    }
}
