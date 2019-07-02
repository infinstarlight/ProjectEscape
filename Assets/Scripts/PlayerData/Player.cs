using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private PlayerStatsScript PlayerStats;

    private void PlayerAwake()
    {
        base.Awake();
        PlayerStats = GetComponentInChildren<PlayerStatsScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayerDamageTaken(float damageTaken)
    {
        OnDamageApplied(damageTaken);
        PlayerStats.UpdateHealthText();
    }
}
