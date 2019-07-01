using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{

    public GameObject spawnPoint;
    public GameObject currentProj;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponentInChildren<ProjSpawnPointScript>().gameObject;
      //  projRB = currentProj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //spawnVector = spawnPoint.transform.position;
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(currentProj, spawnPoint.transform.position,spawnPoint.transform.rotation);
            
            Debug.Log("Fire!");
        }
    }
}
