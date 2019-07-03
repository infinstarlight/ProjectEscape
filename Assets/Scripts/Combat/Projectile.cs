using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    public float BaseDamageAmount = 0;
    public float DamageModifierAmount = 0;
    private float TotalDamageAmount = 0;
    public float ProjDestructDelay = 0f;

    private Rigidbody2D RB;
    public float thrust;
    //private GameObject player;
    private Weapon GetWeapon;
    public GameObject hitTarget;

    private void Awake()
    {
       // player = FindObjectOfType<Player>().gameObject;
        RB = GetComponent<Rigidbody2D>();
        GetWeapon = GetComponentInParent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RB.velocity = (transform.right * thrust);
        CalculateDamage();
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        DestroyProjectile(ProjDestructDelay);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision.gameObject);
        //CalculateDamage();
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            hitTarget = collision.gameObject;
            hitTarget.GetComponent<Character>().OnDamageApplied(TotalDamageAmount);
            DestroyProjectile(0f);
        }
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            hitTarget = collision.gameObject;
            hitTarget.GetComponent<Player>().PlayerDamageTaken(TotalDamageAmount);
            DestroyProjectile(0f);
        }
    }


    void DestroyProjectile(float DestroyDelay)
    {
        Destroy(gameObject, DestroyDelay);
    }

    void CalculateDamage()
    {
        TotalDamageAmount = (BaseDamageAmount + (1 * DamageModifierAmount));
    }

    private void OnDestroy()
    {
        
    }
}
