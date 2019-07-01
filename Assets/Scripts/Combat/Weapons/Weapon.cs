using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public GameObject projectileGO;
    public Projectile GetProjectile;
    public GameObject spawnPoint;
    
    public bool bHasAmmo = false;
    public bool bCanFire = false;
    public int CurrentAmmo = 0;
    public int MaxAmmo = 0;
    public int AmmoConsumeAmount = 0;
    public bool bShouldConsumeAmmo;



    public void Awake()
    {
        if(projectileGO == null)
        {
            Debug.LogError(gameObject.name + " Has no Projectile!");
        }
        spawnPoint = GetComponentInChildren<ProjSpawnPointScript>().gameObject;
        CheckAmmo();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootProjectile()
    {
        if(projectileGO != null)
        {
            Instantiate(projectileGO, spawnPoint.transform.position,spawnPoint.transform.rotation);
            ConsumeAmmo();
            CheckAmmo();
        }
    }


    void CheckAmmo()
    {
        if (MaxAmmo > 0)
        {
            bHasAmmo = true;
        }
        if (bHasAmmo)
        {
            if (CurrentAmmo > 0)
            {
                bCanFire = true;
            }
            else
            {
                bCanFire = false;
            }
            
        }
    }

    void ConsumeAmmo()
    {
        if (bShouldConsumeAmmo)
        {
            CurrentAmmo -= AmmoConsumeAmount;
        }
    }

    public void InitalizeAmmo(int StartingAmmo, int StartingMaxAmmo, bool ShouldConsumeAmmo, int ConsumeAmmout)
    {
        CurrentAmmo = StartingAmmo;
        MaxAmmo = StartingMaxAmmo;
        AmmoConsumeAmount = ConsumeAmmout;
        bShouldConsumeAmmo = ShouldConsumeAmmo;
    }
}
