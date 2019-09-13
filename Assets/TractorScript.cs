using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorScript : MonoBehaviour
{

    private PlayerDreamkiss dkScript;

    void Awake()
    {
        dkScript = FindObjectOfType<PlayerDreamkiss>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(dkScript.currentSpecialAbility == dkScript.)
    }
}
