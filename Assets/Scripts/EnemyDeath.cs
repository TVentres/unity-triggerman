using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject item1;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Die()
    {
        GameObject obj = Instantiate(item1, Vector3.zero, Quaternion.Euler(0,0,90), transform) as GameObject;
        
        obj.transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);

        // Now unassign the parent
        obj.transform.parent = null;
        //kill the parent which should be the enemy object attatched to this model
        Destroy(this.transform.parent.gameObject);
        Destroy(gameObject);
    }
}