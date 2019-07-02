using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Character : MonoBehaviour,IKillable,IDamageable<float>
{
    public CharacterStatsScript CharacterStats;
    private AudioSource source;
    public AudioClip[] hurtClips;
    public AudioClip deathClip;

    public void Awake()
    {
        CharacterStats = GetComponentInChildren<CharacterStatsScript>();
        source = GetComponent<AudioSource>();
        if (CharacterStats != null)
        {
            Debug.Log("Character Stats is present!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath()
    {
        if(CharacterStats.bIsDead)
        {
            source.clip = deathClip;
            source.PlayOneShot(source.clip);
            Destroy(gameObject, 2f);
        }
        
    }

    public void OnDamageApplied(float damageTaken)
    {
        CharacterStats.CurrentHealth -= damageTaken;
        source.clip = hurtClips[Random.Range(0, 3)];
        source.PlayOneShot(source.clip);
        if(CharacterStats.CurrentHealth <= 0)
        {
            CharacterStats.bIsDead = true;
            OnDeath();
            
        }
    }
}
