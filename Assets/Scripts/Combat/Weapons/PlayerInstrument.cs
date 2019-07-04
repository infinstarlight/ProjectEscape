using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstrument : Weapon
{
    public enum ElementType { Basic, Plasma, Nova, Freeze };
    public ElementType currentElementType;

    void InstrumentAwake()
    {
        base.Awake();
        
   
    }

    // Start is called before the first frame update
    void Start()
    {
        FireClip = Resources.Load<AudioClip>("SFX/Weapons/Player/PI_Fire");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();

            Debug.Log("Fire!");
        }
    }
}
