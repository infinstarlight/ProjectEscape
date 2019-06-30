using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStatsScript CharacterStats;
    // Start is called before the first frame update
    void Start()
    {
        CharacterStats = GetComponentInChildren<CharacterStatsScript>();
        if(CharacterStats != null)
        {
            Debug.Log("Character Stats is present!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
