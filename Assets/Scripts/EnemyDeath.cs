using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //item to be spawned on death
    public GameObject item1;
    
    // Start is called before the first frame update
    void update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Die();
        }
    }

    // Update is called once per frame
    public void Die()
    {
        //Create item1 in this position
        GameObject obj = Instantiate(item1, transform.position, transform.rotation) as GameObject;
        
        //destroy the object attatched to this script (this enemy object)
        Object.Destroy(this.gameObject);
    }
}