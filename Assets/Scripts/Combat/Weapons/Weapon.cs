using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    private AudioSource source;
    public GameObject projectileGO;
    public Projectile GetProjectile;
    private GameObject spawnPoint;
    
    public bool bHasAmmo = false;
    public bool bCanFire = false;
    public int CurrentAmmo = 0;
    public int MaxAmmo = 0;
    public int AmmoConsumeAmount = 0;
    public bool bShouldConsumeAmmo = false;

    public AudioClip FireClip;
    public AudioClip EmptyClip;


    //private Character GetCharacter;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
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
         if(FireClip != null)
        {
            source.clip = FireClip;
        }
    }
    public void ShootProjectile()
    {
        if(projectileGO != null && bCanFire)
        {
            Instantiate(projectileGO, spawnPoint.transform.position, spawnPoint.transform.rotation);
            
            ConsumeAmmo();
            CheckAmmo();
            if(source.clip != FireClip && FireClip != null)
            {
                source.clip = FireClip;
            }
            source.PlayOneShot(source.clip);
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
