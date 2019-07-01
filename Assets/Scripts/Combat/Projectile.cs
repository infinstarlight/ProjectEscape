using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D RB;
    public float thrust;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = (transform.right * thrust);

        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        DestroyProjectile();

       // RB.AddForce(transform.right * thrust);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != player)
        {
            DestroyProjectile();
        }
    }


    void DestroyProjectile()
    {
        Destroy(gameObject, 2f);
    }
}
