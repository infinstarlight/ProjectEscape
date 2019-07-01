using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour,IKillable,IDamageable<float>
{
    public CharacterStatsScript CharacterStats;


    private void Awake()
    {
        CharacterStats = GetComponentInChildren<CharacterStatsScript>();
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

    }

    public void OnDamageApplied(float damageTaken)
    {
        CharacterStats.CurrentHealth -= damageTaken;
    }
}
