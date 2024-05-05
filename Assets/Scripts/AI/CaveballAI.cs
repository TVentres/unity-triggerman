using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveballAI : MonoBehaviour
{
    private GameObject player;
    public Vector3 playerPos;
    public float speed = 6.0f;
    public float size = 4.0f;
    private int hit=10;
    public int damage;
    HUDManager hudManager;
    // Update is called once per frame

    void Start()
    {
        player=GameObject.Find("FlintTriggerModel");
    }

    void Update ()
    {
     playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
     //Here, the zombie's will follow the waypoint.
     transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
     //Debug.Log( transform.position); 
     if(player.transform.position.x>=transform.position.x-size&&
     player.transform.position.x<=transform.position.x+size&&
     player.transform.position.z>=transform.position.z-size&&
     player.transform.position.z<=transform.position.z+size&&
     GameObject.Find("Player_01").GetComponent<TakeDamageTimer>().canHit)
     {
        HUDManager hudManager = FindObjectOfType<HUDManager>();
		hudManager.TakeDamage(damage);
		hit++;
        GameObject.Find("Player_01").GetComponent<TakeDamageTimer>().gotHit();
        //Debug.Log("Hit: "+hit);
     }
     //if(player.transform.position.x==transform.position.x&&player.transform.position.z==transform.position.z)
        //Debug.Log("Hit!!");
    }
}
