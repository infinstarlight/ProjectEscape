using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsScript : MonoBehaviour
{

    public float CurrentHealth = 0.0f;
    public float MaxHealth = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
