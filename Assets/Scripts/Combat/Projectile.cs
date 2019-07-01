using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float BaseDamageAmount = 0;
    public float DamageModifierAmount = 0;
    private float TotalDamageAmount = 0;

    private Rigidbody2D RB;
    public float thrust;
    private GameObject player;
    private GameObject hitTarget;

    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
        RB = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RB.velocity = (transform.right * thrust);
        TotalDamageAmount = (BaseDamageAmount + (1 * DamageModifierAmount));
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        DestroyProjectile(3f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        //if(collision.gameObject != player)
        //{
        //    DestroyProjectile(0.0f);
        //}
        if(collision.gameObject.GetComponent<Character>() != null)
        {
            hitTarget = collision.gameObject;
            hitTarget.GetComponent<Character>().OnDamageApplied(TotalDamageAmount);
        }
    }


    void DestroyProjectile(float DestroyDelay)
    {
        Destroy(gameObject, DestroyDelay);
    }
}
