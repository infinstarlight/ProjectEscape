using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsScript : MonoBehaviour
{

    public float CurrentHealth = 0.0f;
    public float MaxHealth = 100.0f;
    public bool bIsDead = false;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ModifyHealth(int ModAmount)
    {
        CurrentHealth += ModAmount;
    }
    
}
