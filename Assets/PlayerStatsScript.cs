﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public bool bDebugStats = false; 
    private ID_HealthText healthText;
    private DK_AmmoTextScript DK_AmmoText;
    private PlayerInstrument playerInstrument;
    private PlayerDreamkiss playerDreamkiss;
    private CharacterStatsScript playerStats;
    private Player player;

    private void Awake()
    {
        healthText = FindObjectOfType<ID_HealthText>();
        DK_AmmoText = FindObjectOfType<DK_AmmoTextScript>();
        playerInstrument = FindObjectOfType<PlayerInstrument>();
        playerDreamkiss = FindObjectOfType<PlayerDreamkiss>();
        playerStats = GetComponent<CharacterStatsScript>();
        player = GetComponentInParent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthText();
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        if(bDebugStats)
        {
            if(Input.GetKeyDown(KeyCode.Slash))
            {
                player.PlayerDamageTaken(5.0f);
            }
        }
    }

    public void UpdateHealthText()
    {
        healthText.TextMesh.text = playerStats.CurrentHealth.ToString();
    }

    public void UpdateAmmoText()
    {
        DK_AmmoText.TextMesh.text = playerDreamkiss.CurrentAmmo.ToString();
    }
}
