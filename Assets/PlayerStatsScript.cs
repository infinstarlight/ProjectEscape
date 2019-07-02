using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    private ID_HealthText healthText;
    private PlayerInstrument playerInstrument;
    private PlayerDreamkiss playerDreamkiss;
    private CharacterStatsScript playerStats;

    private void Awake()
    {
        healthText = FindObjectOfType<ID_HealthText>();
        playerInstrument = FindObjectOfType<PlayerInstrument>();
        playerDreamkiss = FindObjectOfType<PlayerDreamkiss>();
        playerStats = GetComponent<CharacterStatsScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthText()
    {
        healthText.TextMesh.text = playerStats.CurrentHealth.ToString();
    }

    public void UpdateAmmoText()
    {

    }
}
