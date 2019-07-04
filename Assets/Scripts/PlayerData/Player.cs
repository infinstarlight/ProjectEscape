using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private PlayerStatsScript PlayerStats;
    private ID_AnimExplosive animExplosive;
    private GameObject cameraGO;
    private GameObject userHUDGO;

    private void PlayerAwake()
    {
        Awake();
        cameraGO = Resources.Load<GameObject>("Prefabs/Player/PlayerCamera");
        userHUDGO = Resources.Load<GameObject>("Prefabs/Player/PlayerUI");
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = GetComponentInChildren<PlayerStatsScript>();
        animExplosive = FindObjectOfType<ID_AnimExplosive>();
        animExplosive.gameObject.SetActive(false);
        if(FindObjectOfType<CameraController>() == null)
        {
            cameraGO = Instantiate(cameraGO);
        }
        if (FindObjectOfType<ID_HealthText>() == null)
        {
            userHUDGO = Instantiate(userHUDGO);
        }
        DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(cameraGO);
        //DontDestroyOnLoad(userHUDGO);
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
