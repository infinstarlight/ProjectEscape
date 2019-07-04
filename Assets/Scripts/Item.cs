using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int RecoverAmount = 0;
    private Player GetPlayer;

    private void Start()
    {
        GetPlayer = FindObjectOfType<Player>();
    }

    public void RecoverHealth()
    {
        GetPlayer.CharacterStats.ModifyHealth(RecoverAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            RecoverHealth();
            Destroy(gameObject);
        }
    }
}
