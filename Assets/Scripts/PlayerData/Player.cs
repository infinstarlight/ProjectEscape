using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private PlayerStatsScript PlayerStats;
    private ID_AnimExplosive animExplosive;

    private void PlayerAwake()
    {
        base.Awake();
      
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = GetComponentInChildren<PlayerStatsScript>();
        animExplosive = FindObjectOfType<ID_AnimExplosive>();
        animExplosive.gameObject.SetActive(false);
    }

    public void PlayerDamageTaken(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        PlayerStats.UpdateHealthText();
        if (PlayerStats.playerStats.bIsDead)
        {
            animExplosive.gameObject.SetActive(true);
        }
    }

    public void OnPlayerDeath()
    {
        base.OnDeath();
      
        
    }
}
