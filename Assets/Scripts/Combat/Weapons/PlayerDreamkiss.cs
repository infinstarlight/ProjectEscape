using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDreamkiss : Weapon
{
    
   public enum SpecialAbility {Catcher, Spark, Booster };
    public SpecialAbility currentSpecialAbility;
    private PlayerStatsScript StatsScript;
    private void DreamKissAwake()
    {
        base.Awake();
        InitalizeAmmo(15, 15, true, 1);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StatsScript = FindObjectOfType<PlayerStatsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ShootProjectile();
            StatsScript.UpdateAmmoText();
            //Debug.Log("Dreamkiss!");
        }
    }
}
