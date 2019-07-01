using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float BaseDamageAmount = 0;
    public float DamageModifierAmount = 0;
    private float TotalDamageAmount = 0;


    // Start is called before the first frame update
    void Start()
    {
        TotalDamageAmount = (BaseDamageAmount + (1 * DamageModifierAmount));  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
